using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regions.Services.NewDelegation;

namespace Regions.Model.NewDelegation
{
  public  class AppendixCreator: IAppendixCreator, IAppendixDataExtractor
    {
        readonly string AppendixBase = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt: ";
        string Appendix;
        IAppendixValidator Validator;
        public AppendixCreator(IAppendixValidator _validator)
        {
            Validator = _validator;

        }
        public AppendixCreator(string _appendixbase)
        {
            AppendixBase = _appendixbase;
        }
        public void CreateAppendix(string ProjectName, string ProjectNumber)
        {
           Appendix = AppendixBase + ProjectName + " " + ProjectNumber;
        }

        public string GetAppendix()
        {
            return Appendix;
        }

      public  string ExtractProjectName(string Text)
        {
            if (!Validator.IsAppendixValid(Text))
                return string.Empty;
            int EndOfAppendixBase = Text.IndexOf("Projekt:") + 9;
            string PRojectNumberPrefix = "TUT";
            int StartOdProjectNumber = Text.IndexOf(PRojectNumberPrefix);
            string ProjectName = string.Empty;
            int LengthOfProjectName = StartOdProjectNumber - EndOfAppendixBase -1 ;
            if (LengthOfProjectName < 0)
                return ProjectName;
            if (StartOdProjectNumber < Text.Length)
                ProjectName = Text.Substring(EndOfAppendixBase, LengthOfProjectName);
            return ProjectName;
        }

        public string ExtractProjectNumber(string Text)
        {
            if (!Validator.IsAppendixValid(Text))
                return string.Empty;
            string PRojectNumberPrefix = "TUT";
            int StartOdProjectNumber = Text.IndexOf(PRojectNumberPrefix);
            string ProjectNumber = string.Empty;
            int LengthOfProjectNumber = Text.Length - StartOdProjectNumber -1;
            if (StartOdProjectNumber < 0)
                return ProjectNumber;
            if (StartOdProjectNumber < Text.Length)
                ProjectNumber = Text.Substring(StartOdProjectNumber, LengthOfProjectNumber);
            return ProjectNumber.Replace("\n",string.Empty).Replace("\r",string.Empty);
        }
    }
}
