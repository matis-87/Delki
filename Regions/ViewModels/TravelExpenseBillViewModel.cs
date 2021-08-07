using Microsoft.Win32;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Regions.Controls;
using Regions.Services.CountDelegation;
using Regions.Services.NewDelegation;
using Regions.Services.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using static Regions.Model.Helper.MyExtentions;
using Regions.Model.Helper;
using Regions.Model.CountDelegation;
using System.Threading.Tasks;
using Regions.Model.WebExplorer;
using System.Windows;
using System.Collections.ObjectModel;
using Regions.Model.NewDelegation;

namespace Regions.ViewModels
{
    public class TravelExpenseBillViewModel : BindableBase, INavigationAware
    {
        private Uri bootURI;
        public Uri BootURI
        {
            get { return bootURI; }
            set { SetProperty(ref bootURI, value); }
        }
        private string file;
        public string File
        {
            get { return file; }
            set { SetProperty(ref file, value); }
        }

        private DateTime departureDate;
        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { SetProperty(ref departureDate, value); }
        }

        private string departureTime;
        public string DepartureTime
        {
            get { return departureTime; }
            set { SetProperty(ref departureTime, value); }
        }

        private string travelTime;
        public string TravelTime
        {
            get { return travelTime; }
            set { SetProperty(ref travelTime, value); }
        }

        private DateTime arrivalDate;
        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { SetProperty(ref arrivalDate, value); }
        }
        private string arrivalTime;
        public string ArrivalTime
        {
            get { return arrivalTime; }
            set { SetProperty(ref arrivalTime, value); }
        }

        private string returnTime;
        public string ReturnTime
        {
            get { return returnTime; }
            set { SetProperty(ref returnTime, value); }
        }

        private string overnightBill;
        public string OvernightBill
        {
            get { return overnightBill; ; }
            set { SetProperty(ref overnightBill, value); }
        }

        private string otherExpenses;
        public string OtherExpenses
        {
            get { return otherExpenses; }
            set { SetProperty(ref otherExpenses, value); }
        }

        private int numberOfBreakfast;
        public int NumberOfBreakfast
        {
            get { return numberOfBreakfast; }
            set { SetProperty(ref numberOfBreakfast, value); }
        }


        private string targetCity;
        public string TargetCity
        {
            get { return targetCity; }
            set { SetProperty(ref targetCity, value); }
        }

        private string advance;
        public string Advance
        {
            get { return advance; }
            set { SetProperty(ref advance, value); }
        }

        private string advanceTaken;
        public string AdvanceTaken
        {
            get { return advanceTaken; }
            set { SetProperty(ref advanceTaken, value); }
        }


        private string dietsCost;
        public string DietsCost
        {
            get { return dietsCost; }
            set { SetProperty(ref dietsCost, value); }
        }

        private string sumOfCosts;
        public string SumOfCosts
        {
            get { return sumOfCosts; }
            set { SetProperty(ref sumOfCosts, value); }
        }

        private string toPay;
        public string ToPay
        {
            get { return toPay; }
            set { SetProperty(ref toPay, value); }
        }

        private string returnLabel;
        public string ReturnLabel
        {
            get { return returnLabel; }
            set { SetProperty(ref returnLabel, value); }
        }

        private bool breakfastsInHotel;
        public bool BreakfastsInHotel
        {
            get { return breakfastsInHotel; }
            set { SetProperty(ref breakfastsInHotel, value); }
        }

        private bool isFileChoosen;
        public bool IsFileChoosen
        {
            get { return isFileChoosen; }
            set { SetProperty(ref isFileChoosen, value); }
        }

        private bool isWebPageLoaded;
        public bool IsWebPageLoaded
        {
            get { return isWebPageLoaded; }
            set { SetProperty(ref isWebPageLoaded, value); }
        }

        private ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set { SetProperty(ref projects, value); }
        }

        private string projectName;
        public string ProjectName
        {
            get { return projectName; }
            set { SetProperty(ref projectName, value); }
        }

        private string projectNumber;
        public string ProjectNumber
        {
            get { return projectNumber; }
            set { SetProperty(ref projectNumber, value); }
        }

        private Project selectedProject;
        public Project SelectedProject
        {
            get { return selectedProject; }
            set { SetProperty(ref selectedProject, value); }
        }
        public DelegateCommand BackToMenuCommand { get; private set; }
        public DelegateCommand FillDocumentCommand { get; private set; }
        public DelegateCommand CalculateCostsOfDelegationCommand { get; private set; }
        public DelegateCommand ChooseFileCommand { get; private set; }
        public DelegateCommand<ContentLoadedEventArgs> ContentLoadedCommand { get; private set; }
        public DelegateCommand ProjectSelectionChangedCommand { get; private set;}
        bool IsReadAppendixValid;

        IContainerProvider ContainerProvider;
        IRegionManager RegionManager;
        TimeSpan StopReturnTravel;
        private IJavaScriptExecutor scriptExecutor;
        public IJavaScriptExecutor ScriptExecutor
        {
            get { return scriptExecutor; }
            set { SetProperty(ref scriptExecutor, value); }
        }

        string FullFileName;
        int ContentLoadedCounter;
        const string PageName = "Kalkulator krajowej podróży służbowej - kalkulatory.gofin.pl";
        public TravelExpenseBillViewModel(IContainerProvider _containerManager, IRegionManager _regionManager)
        {

            ChooseFileCommand = new DelegateCommand(ChooseFile);
            FillDocumentCommand = new DelegateCommand(FillDocument).ObservesCanExecute(() => IsFileChoosen);
            CalculateCostsOfDelegationCommand = new DelegateCommand(CalculateCostsOfDelegation).ObservesCanExecute(()=> IsWebPageLoaded);
            ContentLoadedCommand = new DelegateCommand<ContentLoadedEventArgs>(ContentLoaded);
            BackToMenuCommand = new DelegateCommand(NavigateBackToMenu);
            ProjectSelectionChangedCommand = new DelegateCommand(ProjectSelectionChanged);
            RegionManager = _regionManager;
            ContainerProvider = _containerManager;
            ReturnLabel = "Do wypłaty:";
            File = "Wybierz plik delegacji";
            Advance = "0,00";
            OvernightBill = "0,00";
            OtherExpenses = "0,00";
            DepartureTime = "7:00";
            TravelTime = "1:00";
            ArrivalTime = "15:00";
            ReturnTime = "1:00";
            DepartureDate = DateTime.Now;
            ArrivalDate = DateTime.Now;
            BreakfastsInHotel = true;
        }

        public async void ChooseFile()
        {
           await Task.Run(() => { 
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.ShowDialog();
            OpenFile.DefaultExt = ".docx";
            File = OpenFile.SafeFileName;
            FullFileName = OpenFile.FileName;
            using (var Doc = ContainerProvider.Resolve<ICalculationDataReader>())
            {
                IsFileChoosen =  Doc.GetDocument(FullFileName, false);
                if (IsFileChoosen)
                {
                    TargetCity = Doc.GetDestinationCity();
                    Advance = Doc.GetAdvance().ToString();
                    string Appendix = Doc.GetAppendixCell();
                    var AppendixValidator = ContainerProvider.Resolve<IAppendixValidator>();
                    IsReadAppendixValid = AppendixValidator.IsAppendixValid(Appendix);
                    var AppendixCreator = ContainerProvider.Resolve<IAppendixDataExtractor>();
                    ProjectName =  AppendixCreator.ExtractProjectName(Appendix);
                    ProjectNumber = AppendixCreator.ExtractProjectNumber(Appendix);

                }
                else
                    File = "Zły format pliku";
            }
           });
        }

        public void FillDocument()
        {
           var DocumentEditor = ContainerProvider.Resolve<IPostDelegationEditor>();
           DocumentEditor.GetDocument(FullFileName, true);
           string City = DocumentEditor.GetDestinationCity();
           TimeSpan StopTravel =Helpers.CalculateEndOfTravel(DepartureTime.ToTimeSpan(),TravelTime.ToTimeSpan());
           TimeSpan StopReturnTravel = Helpers.CalculateEndOfTravel(ArrivalTime.ToTimeSpan(), ReturnTime.ToTimeSpan());
           DocumentEditor.AddDepartureDetails("Poznań", DepartureDate, DepartureTime.ToTimeSpan(), City, DepartureDate, StopTravel);
           DocumentEditor.AddReturnDetails(City, ArrivalDate, ArrivalTime.ToTimeSpan(), "Poznań", ArrivalDate, StopReturnTravel);
           DocumentEditor.AddCostSettlement(DietsCost, OvernightBill, OtherExpenses);
           DocumentEditor.AddCalculations(SumOfCosts, AdvanceTaken, ToPay);
           DocumentEditor.SpecifySignOfResults(ReturnLabel);
            if (!IsReadAppendixValid)
            {
                var AppendixCreator = ContainerProvider.Resolve<IAppendixCreator>();
                AppendixCreator.CreateAppendix(ProjectName, ProjectNumber);
                DocumentEditor.AddAppendix(AppendixCreator.GetAppendix());
            }

        }

        public void CalculateCostsOfDelegation()
        {
            StopReturnTravel = Helpers.CalculateEndOfTravel(ArrivalTime.ToTimeSpan(), ReturnTime.ToTimeSpan());
            int Breakfasts = 0;
            if (BreakfastsInHotel)
            {
                var BreakfastsCounter = ContainerProvider.Resolve<IBreakfastCounter>();
                Breakfasts = BreakfastsCounter.CountBreakfast(DepartureDate, ArrivalDate);
            }
            var Counter = ContainerProvider.Resolve<ICountDelegationTemplateGenerator>();
            string Script = Counter.FillFomrWithData(DepartureDate, DepartureTime.ToTimeSpan(), ArrivalDate, StopReturnTravel, Breakfasts, OvernightBill, Advance, OtherExpenses);
            ScriptExecutor.ExecuteScript(Script);
        }

        void ContentLoaded(ContentLoadedEventArgs args)
        {
            if (WebValidator.isCurrentPageNameValid(args.PageName, PageName))
            {
                IsWebPageLoaded = true;
                ContentLoadedCounter++;
                if (ContentLoadedCounter == 2)
                {
                    ContentLoadedCounter = 1;
                    ShowCalculationsResults();
                }
            }
            else
            {
               
                MessageBox.Show("Nie można połączyć się z serwerem", "Błąd połączenia z serwerem.", MessageBoxButton.OK, MessageBoxImage.Warning);
                //BootURI = new Uri("https://www.wp.pl/");
            }
        }

        async void  ShowCalculationsResults()
        {
            var Counter = ContainerProvider.Resolve<ICountDelegationTemplateGenerator>();
            string JSONCalculations = await ScriptExecutor.ExecuteScript(Counter.GetCalculations());
            string[] Calculations = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(JSONCalculations);
            DietsCost = Calculations[0];
            AdvanceTaken = Calculations[1];
            SumOfCosts = Calculations[2];
            ToPay = Calculations[3];
            ReturnLabel = Calculations[4];
        }

        void ProjectSelectionChanged()
        {
            ProjectName = SelectedProject.ProjectName ?? string.Empty;
            ProjectNumber = SelectedProject.ProjectNumber ?? string.Empty;
        }

        void NavigateBackToMenu()
        {
            RegionManager.RequestNavigate("ContentRegion", "BootMenu");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var ProjectsProvider = ContainerProvider.Resolve<IProjects>();
            Projects = new ObservableCollection<Project>(ProjectsProvider.GetProjects<Project>());
            BootURI = new Uri("about:blank");
            BootURI = new Uri("https://kalkulatory.gofin.pl/Kalkulator-krajowa-podroz-sluzbowa,12.html");
            IsWebPageLoaded = false;
            ContentLoadedCounter = 0;
        }
    }
}
