using ARMDataManager.Library.Models;
using System.Collections.Generic;

namespace ARMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        ProductModel GetProductById(int productId);
        List<ProductModel> GetProducts();
    }
}