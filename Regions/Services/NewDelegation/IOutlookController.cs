using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
public    interface IOutlookController
    {
        void ConnectToOutlook();
        MailItem CreateMailItem();
    }
}
