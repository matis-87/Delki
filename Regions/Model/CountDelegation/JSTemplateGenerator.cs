using Regions.Services.CountDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.CountDelegation
{
    public class JSTemplateGenerator : ICountDelegationTemplateGenerator
    {
        public string FillFomrWithData(DateTime StartOfDelegation, TimeSpan TimeOfStartDelegation, DateTime EndOfDelegation, TimeSpan TimeOfEndDelegation, int NumbersOfBreakfast, string CostOfAccommodation, string Advance, string OtherExpenses)
        {
            return
              SelectOptionByName("rok_w", StartOfDelegation.ToString(@"yyyy")) +
              SelectOptionByName("mc_w", StartOfDelegation.ToString(@"MM")) +
              SelectOptionByName("dn_w", StartOfDelegation.ToString(@"dd")) +
              SelectOptionByName("godz_w_g", TimeOfStartDelegation.ToString(@"hh")) +
              SelectOptionByName("godz_w_m", TimeOfStartDelegation.ToString(@"mm")) +
              SelectOptionByName("rok_p", EndOfDelegation.ToString(@"yyyy")) +
              SelectOptionByName("mc_p", EndOfDelegation.ToString(@"MM")) +
              SelectOptionByName("dn_p", EndOfDelegation.ToString(@"dd")) +
              SelectOptionByName("godz_p_g", TimeOfEndDelegation.ToString(@"hh")) +
              SelectOptionByName("godz_p_m", TimeOfEndDelegation.ToString(@"mm")) +
              EditInputValueById("stawkaInput", "30,00") +
              EditInputValueById("lSniadanInput", NumbersOfBreakfast.ToString()) +
              EditInputValueById("kosztNoclegowWgRachunkow", CostOfAccommodation.ToString()) +
              EditInputValueById("pobranaZaliczka", Advance.ToString()) +
              EditInputValueByName("inneKwota[]", OtherExpenses.ToString()) +
              PerformClickById("przyciskObliczenia");
        }

        string SelectOptionByName(string ElementName, string Option)
        {
            return
            $"var sel = document.getElementsByName('" + ElementName + "');  " +
            $"var SelOptions = sel[0].options;" +
            $"for(let i=0;i<SelOptions.length;i++){{" +
            $" if(SelOptions[i].text.includes('" + Option + "'))" +
            $" SelOptions.selectedIndex = i;" +
            $" }} ";
        }

        string EditInputValueById(string InputName, string newValue)
        {
            return $"document.getElementById('" + InputName + "').value = '" + newValue + "';";
        }

        string EditInputValueByName(string InputName, string newValue)
        {
            return $"var el = document.getElementsByName('" + InputName + "'); el[0].value='"+ newValue+"';";
        }

        string PerformClickById(string ElementName)
        {
            return $"document.getElementById('" + ElementName + "').click();";
        }

 
        public string GetCalculations()
        {
            return $"function GetElementValue(txt) {{" +
                   $"var temp = document.getElementsByClassName('wynikiTabela'); " +
                   $"var tab = temp[1];" +
                   $"for(let i=0;i<tab.rows.length;i++){{" +
                   $" if(tab.rows[i].cells[0].innerHTML.includes(txt))" +
                   $"return tab.rows[i].cells[1].innerHTML;" +
                   $" }} " +
                   $"return '0,00 zł';" +
                   $"}}" +
                   $"function GetCalculations() {{" +
                   $"const Calculations = []; " +
                   $"var results = GetElementValue('Łączna wysokość diet :');" +
                   $"if(results =='0,00 zł') {{" +
                   $"    results = GetElementValue('Wysokość diet :');" +
                   $"}}" +
                   $"Calculations.push(results);" +
                   $"var results = GetElementValue('Pobrana zaliczka :');" +
                   $"Calculations.push(results);" +
                   $"var results = GetElementValue('Suma kosztów:');" +
                   $"Calculations.push(results);" +
                   $"var results = GetElementValue('Do wypłaty :');" +
                   $"var label = 'Do wypłaty';" +
                   $"if(results =='0,00 zł') {{" +
                   $"    results = GetElementValue('Do zwrotu :');" +
                   $"label = 'Do zwrotu';" +
                   $"}}" +
                   $"Calculations.push(results);" +
                   $"Calculations.push(label);" +
                   $"return Calculations;" +
                   $"}}" +
                    $" GetCalculations();";
        }
    }
}
