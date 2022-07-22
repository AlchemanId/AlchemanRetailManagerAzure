using ARMDataManager.Library.Internal.DataAccess;
using ARMDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDataManager.Library.DataAccess
{
    public class SaleData : ISaleData
    {
        private readonly IProductData _productData;
        private readonly ISqlDataAccess _sql;
        private readonly IConfiguration _config;

        public SaleData(IProductData productData, ISqlDataAccess sql, IConfiguration config)
        {
            this._productData = productData;
            this._sql = sql;
            this._config = config;
        }

        public decimal GetTaxRate()
        {
            string rateTax = _config.GetValue<string>("taxRate"); //ConfigurationManager.AppSettings["taxRate"];

            bool IsValidTaxRate = decimal.TryParse(rateTax, out decimal output);

            if (IsValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly");
            }

            output = output / 100;

            return output;
        }

        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            // TODO: Make this SOILID/DRY/Better
            // start filling in the sale detail models we will save to the database
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            var taxRate = GetTaxRate();

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                // Get the information about this product
                var productInfo = _productData.GetProductById(detail.ProductId);
                if (productInfo == null)
                {
                    throw new Exception($"The product Id of {detail.ProductId} could not be found in the database.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxAble)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            // create the sale model
            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };
            sale.Total = sale.SubTotal + sale.Tax;

            try
            {
                _sql.StartTransaction("ARMData");

                // save the sale model
                _sql.SaveDataInTransaction("dbo.spSaleInsert", sale);

                // get the id from the sale model
                sale.Id = _sql.LoadDataInTransaction<int, dynamic>("dbo.spSaleLookup", new { sale.CashierId, sale.SaleDate }).FirstOrDefault();

                // Finish filling in the sale detail models 
                foreach (var item in details)
                {
                    item.SaleId = sale.Id;

                    // save the sale detail models
                    _sql.SaveDataInTransaction("dbo.spSaleDetailInsert", item);
                }
                _sql.CommitTransaction();
            }
            catch
            {
                _sql.RollbackTransaction();
                throw;
            }
        }
        public List<SaleReportModel> GetSaleReport()
        {
            var output = _sql.LoadData<SaleReportModel, dynamic>("dbo.spSaleReport", new { }, "ARMData");
            return output;
        }
    }
}
