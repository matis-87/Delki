using Regions.Services;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regions.Services.NewDelegation;

namespace Regions.Model.NewDelegation
{
  public  class MailCreator : IMailCreator
    {
        IOutlookController OutlookController;
        IMailContentGenerator MailContentGenerator;
        MailItem MailItem;
        const string Subject = "Delegacja ";
        public MailCreator(IOutlookController _outlookController, IMailContentGenerator _mailContentGenerator)
        {
            OutlookController = _outlookController;
            MailContentGenerator = _mailContentGenerator;
        }

        public void CreateMail(string Name, string Recipient, string Company,  string AttachedFileName)
        {
            OpenNewMail();
            AddSubject(Name);
            ShowMail();
            AddRegularContent(Company);
            AddAttachment(AttachedFileName);
            SpecifyRecipients(Recipient);
  
        }

        public void CreateMailWithTransfer(string FirstName, string Name, string CarbonCopy, string Recipient, string Company, string AccountNumber, string AttachedFileName )
        {
            OpenNewMail();
            AddSubject(Name);
            ShowMail();
            AddContentWithTransfer(FirstName, Name, Company, AccountNumber);
            AddAttachment(AttachedFileName);
            SpecifyRecipients(Recipient, CarbonCopy);

        }

        void OpenNewMail()
        {
           MailItem = OutlookController.CreateMailItem();
        }

        void AddSubject(string Name)
        {
            MailItem.Subject = Subject + Name;
        }

        void AddContentWithTransfer(string FirstName, string Name, string Compoany, string Account)
        {
            string body = MailItem.HTMLBody;
            MailItem.HTMLBody = MailContentGenerator.GetContentWithBankTransfer(FirstName, Name, Compoany, Account) + MailItem.HTMLBody;
        }

        void AddRegularContent(string Compoany)
        {
            MailItem.HTMLBody = MailContentGenerator.GetReguralContent(Compoany) + MailItem.HTMLBody;
        }

        void AddAttachment(string FileName)
        {
            MailItem.Attachments.Add(FileName);
        }

        void SpecifyRecipients(string Recipient, string CarbonCopy = null)
        {
            MailItem.To = Recipient;
            if (CarbonCopy != null)
                MailItem.CC = CarbonCopy;
        }

        void ShowMail()
        {
            MailItem.Display(MailItem);
        }
    }
}
