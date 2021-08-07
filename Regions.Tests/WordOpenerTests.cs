using Microsoft.Office.Interop.Word;
using Moq;
using Regions.Model.NewDelegation;
using Regions.Model.Office;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
 public   class WordOpenerTests
    {

        public WordOpenerTests()
        {

        }
        [Fact]
        public void Open_WhenFileNotFound_ResultsException()
        {
            var Opener = new WordOpener();

            Assert.Throws<COMException>(() => Opener.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-20212.docx", true));
        }

        [Fact]
        public void Open_WhenFileOpened_ResultsSomeObject()
        {
            var Opener = new WordOpener();
            var result =  Opener.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);
            Assert.NotNull(result);
            //Opener.Close();
        }

        [Fact]
        public void Close_WhenTryingToCloseClosedFile_ResultsFalse()
        {
            var Opener = new WordOpener();
            Assert.False(IsFileInUse(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2022.docx"));
        }
        [Fact]
        public void Close_WhenTryingToCloseOpenedFile_ResultsFalse()
        {
            var Opener = new WordOpener();
            Opener.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2022.docx", true);
            Opener.Close();
            Assert.False(IsFileInUse(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2022.docx")); 
        }

        public bool IsFileInUse(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("'path' cannot be null or empty.", "path");

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) { }
            }
            catch (IOException e)
            {
                return true;
            }

            return false;
        }

    }
}
