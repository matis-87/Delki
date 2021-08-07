using Regions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model
{
 public   class MailContentGenerator : IMailContentGenerator
    {
        INameChanger NameChanger;
        public MailContentGenerator(INameChanger _nameChanger)
        {

        }
        public string GetContentWithBankTransfer(string FirstName, string Name, string Company, string Account)
        {
            return "<body> W załączniku przesyłam delegację  " + FirstName + "a " + NameChanger.ChangeName(Name) + "  do firmy " + Company + ". Prośba o jej zatwierdzenie i przesłanie zaliczki na poniższy nr konta. <br>  nr Konta: <b> " + Account + "</b></body>";
        }

        public string GetReguralContent(string Company)
        {
            return "<body> W załączniku przesyłam delegację    do firmy " + Company + "</b></body>";
        }
    }
}
