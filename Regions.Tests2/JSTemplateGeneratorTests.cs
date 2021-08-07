using Regions.Model.CountDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests2
{
    public class JSTemplateGeneratorTests
    {
        [Fact]
        public void FillFomrWithData_WhenElementFilled_ResultsString()
        {
            var Generator = new JSTemplateGenerator();
            var result = Generator.FillFomrWithData(new DateTime(2021, 07, 01), new TimeSpan(07, 00, 00), new DateTime(2021, 07, 05), new TimeSpan(15, 30, 00), 4, "350", "500", "100");
            string Expected = "" +
          $"var sel = document.getElementsByName('rok_w').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('2021'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('mc_w').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('07'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('dn_w').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('01'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('godz_w_g').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('07'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('godz_w_m').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('00'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('rok_p').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('2021'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('mc_p').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('07'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('dn_p').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('05'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('godz_p_g').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('15'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"var sel = document.getElementsByName('godz_p_m').options;" +
          $"for(let i=0;i<sel.length;i++){{" +
          $" if(sel[i].text.includes('30'))" +
          $" sel.selectedIndex = i;" +
          $" }} " +
          $"document.getElementById('stawkaInput').value = '30,00';" +
          $"document.getElementById('lSniadanInput').value = '4';" +
          $"document.getElementById('kosztNoclegowWgRachunkow').value = '350';" +
          $"document.getElementById('pobranaZaliczka').value = '500';";
            Assert.Equal(Expected, result);
        }


    }
}
