using Regions.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Regions.Services.NewDelegation;
using Del = Regions.Model.NewDelegation;
using Regions.Services.Settings;
using Regions.Services.CountDelegation;
using Regions.Model.CountDelegation;
using Regions.Model.Office;
using Regions.Services.Office;
using Regions.Model.NewDelegation;

namespace Regions
{
    public class RegionsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(BootMenu));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(PersonsSettings));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BootMenu>();
            containerRegistry.RegisterForNavigation<NewDelegation>();
            containerRegistry.RegisterForNavigation<Settings>();
            containerRegistry.RegisterForNavigation<PersonsSettings>();
            containerRegistry.RegisterForNavigation<ProjectsSettings>();
            containerRegistry.RegisterForNavigation<TravelExpenseBill>();
            containerRegistry.Register<IEmployees, Del.SettingsProvider>();
            containerRegistry.Register<IProjects, Del.SettingsProvider>();
            containerRegistry.Register<IFillForm, Del.JSTemplateGenerator>();
            containerRegistry.Register<IDownloadDelegation, Del.JSTemplateGenerator>();
            containerRegistry.Register<IAcceptDelegation, Del.JSTemplateGenerator>();
            containerRegistry.Register<IUpperFullNameNormalize, Del.NameNormalizer>();
            containerRegistry.Register<IUpperNameNormalize, Del.NameNormalizer>();
            containerRegistry.Register<IWordOpener, WordOpener>();
            containerRegistry.Register<IOutlookController, Del.OutlookController>();
            containerRegistry.Register<IMailCreator, Del.MailCreator>();
            containerRegistry.Register<IMailContentGenerator, Del.MailContentGenerator>();
            containerRegistry.Register<INameChanger, Del.NameChanger>();
            containerRegistry.Register<IEmployeesSaver, Del.SettingsProvider>();
            containerRegistry.Register<IProjectSaver, Del.SettingsProvider>();
            containerRegistry.Register<IDelegationFileValidator, DelegationFileValidator>();
            containerRegistry.RegisterSingleton<IPreDelegationEditor, DelegationFileEditor>();
            containerRegistry.RegisterSingleton<IPostDelegationEditor, DelegationFileEditor>();
            containerRegistry.Register<ICountDelegationTemplateGenerator, Model.CountDelegation.JSTemplateGenerator>();
            containerRegistry.Register<IBreakfastCounter, BreakfastCounter>();
            containerRegistry.Register<ICalculationDataReader, DelegationFileEditor>();
            containerRegistry.Register<IAppendixCreator, AppendixCreator>();
            containerRegistry.Register<IAppendixValidator, AppendixValidator>();
            containerRegistry.Register<IAppendixDataExtractor, AppendixCreator>();

        }
    }
}