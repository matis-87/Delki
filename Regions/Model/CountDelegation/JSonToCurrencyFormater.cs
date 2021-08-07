using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.CountDelegation
{
  public static class JSonToCurrencyFormater
    {
       static public string JSonToCurrency(string json)
        {
            string result;
            try
            {
               result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(json);
            }
            catch
            {
                return string.Empty;
            }
            string posresult = result.Replace(".", "");
            return posresult.Trim().Replace(',', '.');
        }
    }
}
