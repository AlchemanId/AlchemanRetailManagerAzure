using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            decimal output = 0;

            string rateTax = ConfigurationManager.AppSettings["taxRate"];

            bool IsValidTaxRate = decimal.TryParse(rateTax, out output);

            if (IsValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly");
            }
            return output;
        }
    }
}
