using ARMDataManager.Library.Internal.DataAccess;
using ARMDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDataManager.Library.DataAccess
{
    public class InventoryData
    {
        private readonly IConfiguration _config;

        public InventoryData(IConfiguration config)
        {
            this._config = config;
        }
        public List<InventoryModel> GetInventory()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventoryGetAll", new { }, "ARMData");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            sql.SaveData("dbo.spInventoryInsert", item, "ARMData");
        }
    }
}
