using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Regions.ValidationRules
{
 public   class CurrencyRule: ValidationRule
    {
        public CurrencyRule()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double currency = 0;

            try
            {
                if (((string)value).Length > 0)
                    currency = double.Parse((String)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Podano nieprawidłowy znak. Podaj wartoś w formacie xx.nn");
            }
            return ValidationResult.ValidResult;
        }
    }
}
