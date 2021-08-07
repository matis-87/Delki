using Regions.Model.CountDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
   public class JSTemplateGeneratorTests
    {
        [Fact]
        public void FillFomrWithData_WhenElementFilled_ResultsString()
        {
            var Generator = new JSTemplateGenerator();
            var result = Generator.FillFomrWithData(new DateTime(2021, 07, 01), new TimeSpan(07, 00, 00), new DateTime(2021, 07, 05), new TimeSpan(15, 30, 00), 4, "350", "500", "100");
            string Expected = "" +
            "var sel = document.getElementsByName('rok_w');  var SelOptions = sel[0].options;" +
            "for(let i=0;i<SelOptions.length;i++){" +
            " if(SelOptions[i].text.includes('2021')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('mc_w');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('07')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('dn_w'); " +
            " var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('01')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('godz_w_g');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('07')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('godz_w_m');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('00')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('rok_p');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('2021')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('mc_p');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('07')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('dn_p');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('05')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('godz_p_g');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('15')) SelOptions.selectedIndex = i; } " +
            "var sel = document.getElementsByName('godz_p_m');  " +
            "var SelOptions = sel[0].options;for(let i=0;i<SelOptions.length;i++){ " +
            "if(SelOptions[i].text.includes('30')) SelOptions.selectedIndex = i; } " +
            "document.getElementById('stawkaInput').value = '30,00';" +
            "document.getElementById('lSniadanInput').value = '4';" +
            "document.getElementById('kosztNoclegowWgRachunkow').value = '350';" +
            "document.getElementById('pobranaZaliczka').value = '500';" +
            "var el = document.getElementsByName('inneKwota[]'); " +
            "el[0].value='100';document.getElementById('przyciskObliczenia').click();";

            Assert.Equal(Expected, result);
        }


    }
}
