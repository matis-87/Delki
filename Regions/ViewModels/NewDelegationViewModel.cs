using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Regions.Controls;
using Regions.Model.NewDelegation;
using Regions.Model.WebExplorer;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Regions.ViewModels
{
    public class NewDelegationViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { SetProperty(ref employees, value); }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { SetProperty(ref selectedEmployee, value); }
        }
        private ObservableCollection<string> purposeOfDelegation;
        public ObservableCollection<string> PurposeOfDelegation
        {
            get { return purposeOfDelegation; }
            set { SetProperty(ref purposeOfDelegation, value); }
        }

        private string selectedPurposeOfDelegation;
        public string SelectedPurposeOfDelegation
        {
            get { return selectedPurposeOfDelegation; }
            set { SetProperty(ref selectedPurposeOfDelegation, value); }
        }

        private int selectedPurposeOfDelegationIndex;
        public int SelectedPurposeOfDelegationIndex
        {
            get { return selectedPurposeOfDelegationIndex; }
            set { SetProperty(ref selectedPurposeOfDelegationIndex, value); }
        }
        private int selectedEmployeeIndex;
        public int SelectedEmloyeeIndex
        {
            get { return selectedEmployeeIndex; }
            set { SetProperty(ref selectedEmployeeIndex, value); }
        }

        private ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set { SetProperty(ref projects, value); }
        }

        private Project selectedProject;
        public Project SelectedProject
        {
            get { return selectedProject; }
            set { SetProperty(ref selectedProject, value); }
        }

        private int selectedProjectIndex;
        public int SelectedProjectIndex
        {
            get { return selectedProjectIndex; }
            set { SetProperty(ref selectedProjectIndex, value); }
        }

        private DateTime fromDate;
        public DateTime FromDate
        {
            get { return fromDate; }
            set { SetProperty(ref fromDate, value); }
        }

        private DateTime toDate;
        public  DateTime ToDate
        {
            get { return toDate; }
            set { SetProperty(ref toDate, value); }
        }

        private Double? advance;
        public Double? Advance
        {
            get { return advance; }
            set { SetProperty(ref advance, value); }
        }

        private bool transferToTheAccount;
        public bool TransferToTheAccount
        {
            get { return transferToTheAccount; }
            set { SetProperty(ref transferToTheAccount, value); }
        }

        private bool sendMailRequired;
        public bool SendMailRequired
        {
            get { return sendMailRequired; }
            set { SetProperty(ref sendMailRequired, value); }
        }

        private Uri bootURI;
        public Uri BootURI
        {
            get { return bootURI; }
            set { SetProperty(ref bootURI, value); }
        }
        IRegionManager RegionManager;
        IContainerProvider ContainerProvider;
        int ContentLoadedCounter;
        const string Recipient = "m.narozniak@promag.pl";
        const string PageName = "Dodawanie nowego dokumentu";
        public DelegateCommand BackToMenuCommand { get; private set; }
        public DelegateCommand GenerateDelegationCommand { get; private set; }
        public DelegateCommand<ContentLoadedEventArgs> ContentLoadedCommand { get; private set; }
        public DelegateCommand<DownloadEndedEventArgs> DelegationDownloadedCommand { get; private set; }
        private IJavaScriptExecutor scriptExecutor;
        public IJavaScriptExecutor ScriptExecutor
        {
            get { return scriptExecutor; }
            set { SetProperty(ref scriptExecutor, value); }
        }
       // bool isFirstPageLoaded = false;
        private bool isFirstPageLoaded;
        public bool IsFirstPageLoaded
        {
            get { return isFirstPageLoaded; }
            set { SetProperty(ref isFirstPageLoaded, value); }
        }
        public NewDelegationViewModel(IContainerProvider _containerManager, IRegionManager _regionManager)
        {
            RegionManager = _regionManager;
            ContainerProvider = _containerManager;
            BackToMenuCommand = new DelegateCommand(NavigateBackToMenu);
            GenerateDelegationCommand = new DelegateCommand(GenerateDelegation,()=> { return IsFirstPageLoaded; }).ObservesProperty(()=> IsFirstPageLoaded);
            ContentLoadedCommand = new DelegateCommand<ContentLoadedEventArgs>(ContentLoaded);
            DelegationDownloadedCommand = new DelegateCommand<DownloadEndedEventArgs>(DelegationDownloaded);
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            TransferToTheAccount = true;
            SendMailRequired = true;
            PurposeOfDelegation = new ObservableCollection<string>(new List<string> { "nadzór nad montażem", "montaż", "usługa serwisowa gwarancyjna", "usługa serwisowa płatna" });
            Advance = 0;
        }




        void NavigateBackToMenu()
        {
            RegionManager.RequestNavigate("ContentRegion", "BootMenu");
        }

        void GenerateDelegation()
        {
            var DelegationGenerator = ContainerProvider.Resolve<IFillForm>();
            if ((ContentLoadedCounter == 1)&&(Advance != null))
                ScriptExecutor.ExecuteScript(DelegationGenerator.FillFormWithData(SelectedEmployee.FirstName, SelectedEmployee.Name, FromDate, ToDate, SelectedProject.Company, SelectedProject.City, SelectedPurposeOfDelegation, Advance ?? 0));
        }
        void ContentLoaded(ContentLoadedEventArgs args)
        {
            if (WebValidator.isCurrentPageNameValid(args.PageName, PageName))
            {
                ContentLoadedCounter++;
                if (ContentLoadedCounter > 1)
                {
                    var DelegationGenerator = ContainerProvider.Resolve<IDownloadDelegation>();
                    ScriptExecutor.ExecuteScript(DelegationGenerator.DownloadWordDocument(SelectedEmployee.Name, SelectedEmployee.FirstName));
                    ContentLoadedCounter = 0;
                }
                IsFirstPageLoaded = true;
            }
            else
            {
                MessageBox.Show("NIe można połączyć się z serwerem", "Błąd połączenia z serwerem.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        void DelegationDownloaded(DownloadEndedEventArgs args)
        {
            EditDelegationDocument(args.FileName);
            if (SendMailRequired)
                SendEMail(args.FileName);
        }

        void EditDelegationDocument(string FileName)
        {
            var DocumentEditor = ContainerProvider.Resolve<IPreDelegationEditor>();
            bool SendMailNotRequired = !SendMailRequired;
            DocumentEditor.GetDocument(FileName, SendMailNotRequired);
            if(DocumentEditor.IsSecondedCorrect(SelectedEmployee.FirstName))
            {
                var AppendixCreator = ContainerProvider.Resolve<IAppendixCreator>();
                AppendixCreator.CreateAppendix(SelectedProject.ProjectName, SelectedProject.ProjectNumber);
                DocumentEditor.AddAppendix(AppendixCreator.GetAppendix());
            }    
        }

        void SendEMail(string FileName)
        {
            var MailGenerator = ContainerProvider.Resolve<IMailCreator>();
            if ((TransferToTheAccount)&&(Advance>0))
                MailGenerator.CreateMailWithTransfer(SelectedEmployee.Name, SelectedEmployee.FirstName, SelectedEmployee.Email, Recipient, SelectedProject.Company, SelectedEmployee.AcountNumber, FileName);
            else
                MailGenerator.CreateMail(SelectedEmployee.Name, SelectedEmployee.Email, SelectedProject.Company, FileName);
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            BootURI = new Uri("about:blank");
            BootURI = new Uri("http://erd/239-dodawanie-nowego-dokumentu/lang/pl-PL/ProcessType/1/DocType/15/Folder/277/default.aspx?reporef=%2f214-dodaj-dokument%2flang%2fpl-PL%2fdefault.aspx");

            var EmployeesProvider = ContainerProvider.Resolve<IEmployees>();
            Employees = new ObservableCollection<Employee>(EmployeesProvider.GetEmployees<Employee>().ToList());
            var ProjectsProvider = ContainerProvider.Resolve<IProjects>();
            Projects = new ObservableCollection<Project>(ProjectsProvider.GetProjects<Project>());
            SelectedProjectIndex = 0;
            SelectedEmloyeeIndex = 0;
            SelectedPurposeOfDelegationIndex = 0;
            ContentLoadedCounter = 0;
            IsFirstPageLoaded = false;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
