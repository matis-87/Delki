using Regions.Services;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.NewDelegation
{
   public class JSTemplateGenerator: IFillForm, IDownloadDelegation, IAcceptDelegation
    {
        IUpperFullNameNormalize nameNormalize;
        public JSTemplateGenerator(IUpperFullNameNormalize _nameNormalize)
        {
            nameNormalize = _nameNormalize;
        }
        public string FillFormWithData(string FirstName, string Name, DateTime FromDate, DateTime ToDate, string CompanyName, string Location, string Purpose, Double CashAdvance)
        {

            return
            $"var sel = document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl00_c172_ddlItems').options;" +
            $"for(let i=0;i<sel.length;i++){{" +
            $" if(sel[i].text.includes('" + nameNormalize.NormalizeToUpper(FirstName, Name) + "'))" +
            $" sel.selectedIndex = i;" +
            $" }}" +
            $"document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl01_c173_txt').value = '" + FromDate.ToString("dd-MM-yyyy") + "';" +
            $"document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl02_c174_txt').value = '" + ToDate.ToString("dd-MM-yyyy") + "';" +
            $"document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl03_c176_txt').value = '" + CompanyName + "';" +
            $"document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl04_c175_txt').value = '" + Location + "';" +
            $"var sel = document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl05_c177_ddl').options;" +
            $"for(let i=0;i<sel.length;i++){{" +
            $" if(sel[i].text == '" + Purpose + "')" +
            $" sel.selectedIndex = i;" +
            $" }}" +
            $"var sel = document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl06_c213_ddl').options;" +
            $"for(let i=0;i<sel.length;i++){{" +
            $" if(sel[i].text == 'samochód służbowy')" +
            $" sel.selectedIndex = i;" +
            $" }}" +
            $"document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl07_c507_txt').value = '" + CashAdvance + "';"+
            $"document.getElementById('ctl03_ctl03_ctl01_d_btDoc').click();";
        }

        public string DownloadWordDocument(string FirstName, string Name)
        {
            return
            $"var sel = document.getElementById('ctl03_ctl03_ctl01_d_r_rx_ctl09_c398_ddlItems').options;" +
            $"for(let i=0;i<sel.length;i++){{" +
            $" if(sel[i].text.includes('" + nameNormalize.NormalizeToUpper(FirstName, Name) + "'))" +
            $" sel.selectedIndex = i;" +
            $" }}" +
            $" __doPostBack(\'ctl03$ctl03$ctl01$d$rT$ctl00$l\',\'\');";
        }

        public string AcceptDelegation()
        {
            return $"document.getElementById('ctl03_ctl03_ctl01_d_rTransitions_ctl00_bt').click()";
        }
    }
}
