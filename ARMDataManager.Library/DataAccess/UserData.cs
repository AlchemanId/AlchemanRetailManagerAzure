﻿using ARMDataManager.Library.Internal.DataAccess;
using ARMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new {id = id};
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "ARMData");
            return output;
        }
    }
}