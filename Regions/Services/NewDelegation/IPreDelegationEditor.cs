using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
  public  interface IPreDelegationEditor
    {
        void AddAppendix(string Appendix);
        bool IsSecondedCorrect(string Name);
        bool GetDocument(string FileName, bool isVisible);
    }
}
