using Microsoft.Office.Interop.Word;
using Regions.Model.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Regions.Tests2
{
    public class DelegationFileValidatorTests : IDisposable
    {

        public DelegationFileValidatorTests()
        {

        }
        [Fact]
        public void IsNumberOfTablesVerified_WhenPropperDocumentIsApplied_ReturnsTrue()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsNumberOfTablesVerified(Doc);

            Assert.True(Result);

            Doc.Close();
            App.Quit();
        }
        [Fact]
        public void IsNumberOfTablesVerified_WhenEmptyDocumentIsApplied_ReturnsFalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok1.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsNumberOfTablesVerified(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }
        [Fact]
        public void IsDocumentTitleVerified_WhenEmptyDocumentIsApplied_Returnsfalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok1.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsDocumentTitleVerified(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }
        [Fact]
        public void IsDocumentTitleVerified_WhenDocumentWithWrongTitleApplied_Returnsfalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok2.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsDocumentTitleVerified(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }

        [Fact]
        public void IsDocumentTitleCorrect_WhenTargetLocationOfTitleDoesNotExist_ReturnsFalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok1.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsDocumentTitleVerified(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }
        [Fact]
        public void IsTravelExpenseBillTableValidated_WhenTableHasRightDimensions_ReturnsTrue()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsTravelExpenseBillTableValidated(Doc);

            Assert.True(Result);

            Doc.Close();
            App.Quit();
        }

        [Fact]
        public void IsTravelExpenseBillTableValidated_WhenTableHasFewerRows_ReturnsFalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok2.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsTravelExpenseBillTableValidated(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }
        [Fact]
        public void IsTravelExpenseBillTableValidated_WhenTableHasFewerColumns_ReturnsFalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok3.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsTravelExpenseBillTableValidated(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }

        [Fact]
        public void IsDocumentVerified_WhenAppliedEmptyDocument_ReturnsFalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok1.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsDocumentVerified(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }

        [Fact]
        public void IsDocumentVerified_WhenAppliedDocumentWithWrongTitle_ReturnsFalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok2.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsDocumentVerified(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }
        [Fact]
        public void IsDocumentVerified_WhenAppliedDocumentWithWrongTableDimmensions_ReturnsFalse()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok3.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsDocumentVerified(Doc);

            Assert.False(Result);

            Doc.Close();
            App.Quit();
        }

        [Fact]
        public void IsDocumentVerified_WhenAppliedPropperDocument_ReturnsTrue()
        {
            Document Doc;
            Microsoft.Office.Interop.Word.Application App;
            App = new Microsoft.Office.Interop.Word.Application();
            App.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            Doc = App.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            Doc.ActiveWindow.Selection.WholeStory();

            var Validator = new DelegationFileValidator();

            bool Result = Validator.IsDocumentVerified(Doc);

            Assert.True(Result);

            Doc.Close();
            App.Quit();
        }
        public void Dispose()
        {
            //   TestDocument.Close(false);
            //   WordApp.Quit();
        }
    }
}
