﻿using ARMDataManager.Library.Models;
using System.Collections.Generic;

namespace ARMDataManager.Library.DataAccess
{
    public interface IInventoryData
    {
        List<InventoryModel> GetInventory();
        void SaveInventoryRecord(InventoryModel item);
    }
}