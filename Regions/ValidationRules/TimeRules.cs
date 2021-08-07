using Regions.Model.CountDelegation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Regions.ValidationRules
{
 public   class TimeRules : ValidationRule
    {
       public TimeRules()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            try
            {
                if (((string)value).Length > 0)
                {
                    if (!TimeValidator.isTimeFomratValid((string)value))
                        return new ValidationResult(false, $"Zły format czasu");
                }

            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Zły format czasu");
            }
            return ValidationResult.ValidResult;
        }
    }
}
