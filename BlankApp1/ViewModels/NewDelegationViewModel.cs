using Regions.Model;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Regions.Services;
using System.Collections.Generic;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System.Threading.Tasks;
using System.Threading;
using System;

using Microsoft.Office.Interop.Word;

namespace Regions.ViewModels
{
    public class NewDelegationViewModel : BindableBase
    {

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        private IJavaScriptExecutor _jsProvider;
        public IJavaScriptExecutor JavaScriptProvider

        {
            get { return _jsProvider; }
            set { SetProperty(ref _jsProvider, value); }
        }


        private IList<Employee> _employees;
        public IList<Employee> Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }


        private IList<Project> _projects;
        public IList<Project> Projects
        {
            get { return _projects; }
            set { SetProperty(ref _projects, value); }
        }



        public  string uri { get; private set; }
        public DelegateCommand<IContentPageNameWriter> ContentPageLoaded { get; private set; }
        public DelegateCommand<IDownloadedDocument> DocumentDownloaded { get; private set; }
        IContainerProvider cProvider;
        bool isFormFilled = false;


        public   NewDelegationViewModel(IContainerProvider containerProvider)
        {
            uri = "https://www.onet.pl/";
            ContentPageLoaded = new DelegateCommand<IContentPageNameWriter>(OnContentPageLoaded);
            DocumentDownloaded = new DelegateCommand<IDownloadedDocument>(OnDocumentDownloaded);
            cProvider = containerProvider;
            var EmployeesContainer = cProvider.Resolve<IEmployees>();
            Employees = (IList <Employee>)EmployeesContainer.GetEmployees<Employee>();
            var ProjectsContainer = cProvider.Resolve<IProjects>();
            Projects = (IList<Project>)ProjectsContainer.GetProjects<Project>();
            int h = 0;
            var script = cProvider.Resolve<IDownloadDelegation>();
            string dd = script.DownloadWordDocument("Skuza", "Mateusz");
            //PropertyName.Add(new Employee { FirstName = "Skuza", Name = "Mateusz", Email = "m.skuza@promag.pl", AcountNumber = "1000 0000" });
            int hs = 0;
            var word = cProvider.Resolve<IWordEditor>();
            word.EditDocument("ss", true, " ", " ", " ");

           // word.Documents.Open()
        }

        async void OnGenerateCommand()
        {
            var FormGenerator = cProvider.Resolve<IFillForm>();
          //  await JavaScriptProvider.ExecuteScript(FormGenerator.FillFormWithData());
            isFormFilled = true;
        }
       async  void OnContentPageLoaded(IContentPageNameWriter obj)
        {
           if(isFormFilled)
            {
                var DocumentDownloader = cProvider.Resolve<IDownloadDelegation>();
             await   JavaScriptProvider.ExecuteScript(DocumentDownloader.DownloadWordDocument("dd", "ddd"));
            }

        }

        async void OnDocumentDownloaded(IDownloadedDocument document)
        {
            var AcceptDelegation = cProvider.Resolve<IAcceptDelegation>();
            await JavaScriptProvider.ExecuteScript(AcceptDelegation.AcceptDelegation());
            isFormFilled = false;
        }
    }
}
