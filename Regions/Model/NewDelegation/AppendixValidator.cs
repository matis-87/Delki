using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.NewDelegation
{
 public   class AppendixValidator : IAppendixValidator
    {
        public bool IsAppendixValid(string Appendix)
        {
            string AppendixBase = "\rkonto: 509 \rMPK: PSPSPROD\rRodzaj: 4D - KRA - 3 \r\r Projekt: ";
            string TrimmedAppendixBase = AppendixBase.Trim().Replace(" ", string.Empty).Replace("\r", string.Empty);
            string TrimmedAppendix = Appendix.Trim().Replace(" ", string.Empty).Replace("\r", string.Empty);
            try
            {
                if (TrimmedAppendix.Contains(TrimmedAppendixBase))
                    return true;
            }
            catch (NullReferenceException e)
            {
                return false;
            }
            return false;
        }
    }
}
