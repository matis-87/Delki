using Regions.Services;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model
{
    public class OutlookController : IOutlookController
    {
        Application MailClient;
        public OutlookController()
        {
            MailClient = new Application();
        }
        public void ConnectToOutlook()
        {
            MailClient.Application.ActiveWindow();
            NameSpace OutlookNameSpace = MailClient.GetNamespace("mapi");
            OutlookNameSpace.Logon(Missing.Value, Missing.Value, true, true);
        }

        public MailItem CreateMailItem()
        {
            return (MailItem)MailClient.CreateItem(OlItemType.olMailItem);
        }
    }
}
