using Regions.Services;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.NewDelegation
{
  public  class NameChanger : INameChanger
    {
        public string ChangeName(string Name)
        {
            int NameLength = Name.Length;
            string Suffix = Name.Substring(NameLength - 3);
            if (Suffix.Equals("ski"))
            {
                return Name + "ego";
            }
            if (Suffix[2].Equals('a'))
            {

                return Name.Substring(0, NameLength - 1) + "y";
            }
            return Name + "a";
        }
    }
}
