using Microsoft.Office.Interop.Word;
using Moq;
using Regions.Model.CountDelegation;
using Regions.Model.NewDelegation;
using Regions.Services.NewDelegation;
using Regions.Services.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
 public  class DelegationFileEditorTests: IDisposable
    {

        public DelegationFileEditorTests()
        {

        }

        [Fact]
        public void IsSecondedCorrect_WhenInputIsValid_ReturnsTrue()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            var result = Editor.IsSecondedCorrect("Napierała");

            Assert.True(result);


            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void IsSecondedCorrect_WhenInputIsNotValid_ReturnsFalse()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Skuza")).Returns("SKUZA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            var result = Editor.IsSecondedCorrect("Skuza");

            Assert.False(result);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void GetCity_WhenInputIsValid_ReturnsCurrentCity()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);
            string Result = Editor.GetDestinationCity();

            Assert.Equal("Radom", Result);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void GetCity_WhenCannotFindCity_ReturnsEmptyString()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Dok1.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);
            string Result = Editor.GetDestinationCity();

            Assert.Equal(String.Empty, Result);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void AddAppendix_WhenAppendixAdded_ResultsApearingInCorrectCellInTable()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            string Expected = "jakiś appendix";
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);

            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Editor.AddAppendix("jakiś appendix");

            Assert.Equal(Expected+"\r", TestDocument.Tables[1].Cell(2, 2).Range.Text);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void AddDepartureDetails_WhenDataAdded_ResultsAppearingInDocument()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Editor.AddDepartureDetails("Poznań", new DateTime(2021, 07, 16), new TimeSpan(07, 00, 00), "Radom", new DateTime(2021, 07, 16), new TimeSpan(10, 30, 00));


            Assert.Equal("Poznań\r", TestDocument.Tables[4].Cell(3, 1).Range.Text);
            Assert.Equal("16.07.21\r", TestDocument.Tables[4].Cell(3, 2).Range.Text);
            Assert.Equal("07:00:00\r", TestDocument.Tables[4].Cell(3, 3).Range.Text);
            Assert.Equal("Radom\r", TestDocument.Tables[4].Cell(3, 4).Range.Text);
            Assert.Equal("16.07.21\r", TestDocument.Tables[4].Cell(3, 5).Range.Text);
            Assert.Equal("10:30:00\r", TestDocument.Tables[4].Cell(3, 6).Range.Text);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void AddReturnDetails_WhenDataAdded_ResultsAppearingInDocument()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);

            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Editor.AddReturnDetails("Radom", new DateTime(2021, 07, 16), new TimeSpan(15, 00, 00), "Poznań", new DateTime(2021, 07, 16), new TimeSpan(19, 30, 00));

            Assert.Equal("Radom\r", TestDocument.Tables[4].Cell(4, 1).Range.Text);
            Assert.Equal("16.07.21\r", TestDocument.Tables[4].Cell(4, 2).Range.Text);
            Assert.Equal("15:00:00\r", TestDocument.Tables[4].Cell(4, 3).Range.Text);
            Assert.Equal("Poznań\r", TestDocument.Tables[4].Cell(4, 4).Range.Text);
            Assert.Equal("16.07.21\r", TestDocument.Tables[4].Cell(4, 5).Range.Text);
            Assert.Equal("19:30:00\r", TestDocument.Tables[4].Cell(4, 6).Range.Text);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public async void GetDocument_WhenOpenedEmptyDocument_ReturnsFalse()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");

            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(false);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);

            var Result = Editor .GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Assert.False(Result);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void GetDocument_WhenOpenedEmptyDocument_ReturnsTrue()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");

            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);

            var Result = Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Assert.True(Result);

            TestDocument.Close();
            WordApp.Quit();
        }
        [Fact]
        public void AddCostSettlement_WhenDataAdded_ResultsAppearingInDocument()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);


            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Editor.AddCostSettlement("57,30 zł", "150,00 zł", "123,45 zł");

            Assert.Equal("57\r", TestDocument.Tables[4].Cell(14, 4).Range.Text);
            Assert.Equal("30\r", TestDocument.Tables[4].Cell(14, 5).Range.Text);
            Assert.Equal("150\r", TestDocument.Tables[4].Cell(15, 4).Range.Text);
            Assert.Equal("00\r", TestDocument.Tables[4].Cell(15, 5).Range.Text);
            Assert.Equal("123\r", TestDocument.Tables[4].Cell(17, 4).Range.Text);
            Assert.Equal("45\r", TestDocument.Tables[4].Cell(17, 5).Range.Text);
            TestDocument.Close(false);
            WordApp.Quit(false);
        }

        [Fact]
        public void AddCalculations_WhenDataAdded_ResultsAppearingInDocument()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);


            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Editor.AddCalculations("150,50 zł", "300,00 zł", "450,50 zł");

            Assert.Equal("150\r", TestDocument.Tables[4].Cell(32, 3).Range.Text);
            Assert.Equal("50\r", TestDocument.Tables[4].Cell(32, 4).Range.Text);
            Assert.Equal("300\r", TestDocument.Tables[4].Cell(33, 4).Range.Text);
            Assert.Equal("00\r", TestDocument.Tables[4].Cell(33, 5).Range.Text);
            Assert.Equal("450\r", TestDocument.Tables[4].Cell(34, 4).Range.Text);
            Assert.Equal("50\r", TestDocument.Tables[4].Cell(34, 5).Range.Text);
            TestDocument.Close(false);
            WordApp.Quit(false);
        }

        [Fact]
        public void SpecifySignOfResults_WhenAddedPositiveValue_ResultsTekxDoWyplaty()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);


            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Editor.SpecifySignOfResults("Do wypłaty");

            Assert.Equal("Do wypłaty\r", TestDocument.Tables[4].Cell(34, 3).Range.Text);
            TestDocument.Close(false);
            WordApp.Quit(false);
        }


        [Fact]
        public void SpecifySignOfResults_WhenAddedNegativeValue_ResultsTekxDoWyplaty()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);


            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2021.docx", true);

            Editor.SpecifySignOfResults("Do zwrotu");

            Assert.Equal("Do zwrotu\r", TestDocument.Tables[4].Cell(34, 3).Range.Text);
            TestDocument.Close(false);
            WordApp.Quit(false);
        }

        [Fact]
        public void GetAdvance_WhenInputIsValid_ReturnsCurrentAdvance()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2022.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2022.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2022.docx", true);
            double Result = Editor.GetAdvance();

            Assert.Equal(153.45, Result);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void GetAdvance_WhenUnableToFindAdvance_ReturnsZero()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Raport WM.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Raport WM.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Raport WM.docx", true);
            double Result = Editor.GetAdvance();

            Assert.Equal(0, Result);

            TestDocument.Close();
            WordApp.Quit();
        }

        [Fact]
        public void  GetAppendixCell_WhenCelHasText_ReturnsText()
        {
            Document TestDocument;
            Microsoft.Office.Interop.Word.Application WordApp;
            string DocTekst;
            WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = true;
            object fileName = @"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\PW-1567-2022.docx";
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            TestDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            TestDocument.ActiveWindow.Selection.WholeStory();
            DocTekst = TestDocument.ActiveWindow.Selection.Text;

            var Mock = new Mock<IWordOpener>();
            Mock.Setup(x => x.Open(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Raport WM.docx", true)).Returns(TestDocument);
            var NormalizeMock = new Mock<IUpperNameNormalize>();
            NormalizeMock.Setup(x => x.NormalizeNameToUpper("Napierała")).Returns("NAPIERAŁA");
            var ValidatorMock = new Mock<IDelegationFileValidator>();
            ValidatorMock.Setup(x => x.IsDocumentVerified(It.IsAny<Document>())).Returns(true);
            var Editor = new DelegationFileEditor(Mock.Object, NormalizeMock.Object, ValidatorMock.Object);
            Editor.GetDocument(@"C:\Users\mskuza\Documents\04.Dokumenty\Delegacje\Waldek\Raport WM.docx", true);
            string Result = Editor.GetAppendixCell();

            Assert.Equal("\rTG MOD SYS\rTUT/105/20\r\r", Result);

            TestDocument.Close();
            WordApp.Quit();
        }
        public void Dispose()
        {

        }


    }

}
