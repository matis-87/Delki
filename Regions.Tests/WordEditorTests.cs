using Microsoft.Office.Interop.Word;
using Moq;
using Regions.Model.Office;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
  public class WordEditorTests: IDisposable
    {
        Document TestDocument;
        string DocTekst;
        Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
        public WordEditorTests()
        {

            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

        }
        [Fact]
        public  void GetDocument_WhenFileIsOpened_ResultsTrue()
        {     
            var mock = new Mock<IWordOpener>();
            mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var Editor = new WordEditor(mock.Object);
            var result =  Editor .GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);
            Assert.True(result);        
        }
        [Fact]
        public  void GetDocument_WhenFileIsNotOpened_ResultsFalse()
        {
            Document SecondTestDocument = null;
            var mock = new Mock<IWordOpener>();
            mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(SecondTestDocument);
            var Editor = new WordEditor(mock.Object);
            var result = Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);
            Assert.False(result);
        }

        [Fact]
        public void GetDocumentText_WhenFileIsReadCorrectly_ResultsWholeTextOfDocument()
        {
            var mock = new Mock<IWordOpener>();
            mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var Editor = new WordEditor(mock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Assert.Equal(DocTekst, Editor.GetDocumentText());
        }



        public void Dispose()
        {
            WordApp?.Quit();
        }
    }
}
