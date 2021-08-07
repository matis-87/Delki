using Moq;
using Regions.Model.NewDelegation;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests2
{
    public class AppendixCreatorTests
    {
        [Fact]
        public void CreateAppendix_WhenPRojectNameAndPRojectNumberAdded_GetAppendixReturnsCorrectAppendix()
        {
            string Name = "TrendGlass";
            string Number = "TUT/042/20";
            string ExpectedResult = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt: TrendGlass TUT/042/20";
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(true);
            var App = new AppendixCreator(mock.Object);
            App.CreateAppendix(Name, Number);

            Assert.Equal(ExpectedResult, App.GetAppendix());
        }

        [Fact]
        public void ExtractProjectNameFromText_WhenNotAppendixIsGiven_ReturnsEmptyString()
        {
            string TextExample = "\nkonto: 50cdsTrendGlass TUT/042/19";
            string Expeced = string.Empty;
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(false);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectName(TextExample);

            Assert.Equal(Expeced, Result);
        }

        [Fact]
        public void ExtractProjectNameFromText_WhenProjectNameExists_ReturnsProjectName()
        {
            string TextExample = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt: TrendGlass TUT/042/19";
            string Expeced = "TrendGlass";
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(true);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectName(TextExample);

            Assert.Equal(Expeced, Result);
        }

        [Fact]
        public void ExtractProjectNameFromText_WhenProjectNameDoesNotExist_ReturnsEmptyString()
        {
            string TextExample = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt:TUT/042/19";
            string Expeced = string.Empty;
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(true);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectName(TextExample);

            Assert.Equal(Expeced, Result);
        }


        [Fact]
        public void ExtractProjectNameFromText_WhenProjectNumberDoesNotExist_ReturnsEmptyString()
        {
            string TextExample = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt: TG";
            string Expeced = string.Empty;
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(true);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectName(TextExample);

            Assert.Equal(Expeced, Result);
        }

        [Fact]
        public void ExtractProjectNameFromText_WhenProjectNumberAndProjectNameDoNotExist_ReturnsEmptyString()
        {
            string TextExample = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt:";
            string Expeced = string.Empty;
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(true);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectName(TextExample);

            Assert.Equal(Expeced, Result);
        }




        [Fact]
        public void ExtractProjectNumberFromText_WhenProjectNumberExists_ReturnsProjectNumber()
        {
            string TextExample = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt: TrendGlass TUT/042/19";
            string Expeced = "TUT/042/19";
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(true);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectNumber(TextExample);

            Assert.Equal(Expeced, Result);
        }

        [Fact]
        public void ExtractProjectNumberFromText_WhenProjectNumberDoesNotExist_ReturnsEmptyString()
        {
            string TextExample = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt: TrendGlass ";
            string Expeced = string.Empty;
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(true);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectNumber(TextExample);

            Assert.Equal(Expeced, Result);
        }

        [Fact]
        public void ExtractProjectNumberFromText_WhenNotAppendixIsGiven_ReturnsEmptyString()
        {
            string TextExample = "\nkonto: 50cdsTrendGlass TUT/042/19";
            string Expeced = string.Empty;
            var mock = new Mock<IAppendixValidator>();
            mock.Setup(x => x.IsAppendixValid(It.IsAny<string>())).Returns(false);
            var App = new AppendixCreator(mock.Object);
            string Result = App.ExtractProjectNumber(TextExample);

            Assert.Equal(Expeced, Result);
        }


    }
}
