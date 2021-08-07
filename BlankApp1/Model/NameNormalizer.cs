using Regions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model
{
   public  class NameNormalizer : IUpperFullNameNormalize, IUpperNameNormalize
    {
        public string NormalizeToUpper(string FirstName, string Name)
        {
            return FirstName.ToUpper() + " " + Name;
        }

        public string NormalizeNameToUpper(string FirstName)
        {
            return FirstName.ToUpper();
        }

        public string NormalizeToLower(string FirstName, string Name)
        {
            return FirstName.ToLower() + " " + Name.ToLower();
        }
    }
}
