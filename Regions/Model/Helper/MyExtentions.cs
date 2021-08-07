using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.Helper
{
   public static class MyExtentions
    {
        public static TimeSpan ToTimeSpan( this String str)
        {
            if (str is null)
                return new TimeSpan(0);
            try
            {
               return TryToTimeSpan(str);
            }
            catch
            {
                return new TimeSpan(0);
            }
        }

        static TimeSpan TryToTimeSpan(this String str)
        {
            string[] ingredients = str.Split(':');
            if (ingredients.Length < 3)
                return new TimeSpan(Convert.ToInt32(ingredients[0]), Convert.ToInt32(ingredients[1]), 00);
            else
                return new TimeSpan(Convert.ToInt32(ingredients[0]), Convert.ToInt32(ingredients[1]), Convert.ToInt32(ingredients[2]));
        }
 
        public static int GetIntegralPart(this double Number)
        {
            return (int)Number;
        }
        public static string GetIntegralPart(this string Number)
        {
            string[] substring = Number.Split(',');
            if ((substring[0].Equals("0")) || (substring[0].Equals("00")))
                return string.Empty;
            return substring[0];
        }
        public static string GetFractionalPart(this string Number)
        {
            try
            {
                string temp = Number.Replace(" zł", string.Empty);
                string[] substring = temp.Split(',');
                if (substring.Length > 0)
                {
                    if (((substring[1].Equals("0")) || (substring[1].Equals("00")))&&(Number.GetIntegralPart() == string.Empty))
                        return string.Empty;
                    return substring[1];
                }
                else
                    return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static int GetFractionalPart(this double Number)
        {
            int a = (int)(Number * 100);
            int b = ((int)(Number)) * 100;
            return a - b;
        }
    }
}
