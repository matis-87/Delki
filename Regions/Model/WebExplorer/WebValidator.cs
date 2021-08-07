using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.WebExplorer
{
public class WebValidator
    {
     static   public bool isCurrentPageNameValid(string CurrentWebPageName, string ExpectedWebPageName)
        {
            if (CurrentWebPageName.Equals(ExpectedWebPageName))
                return true;
            return false;
        }
    }
}
