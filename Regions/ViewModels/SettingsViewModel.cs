using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Regions.ViewModels
{
    public class SettingsViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand BackToBootMenuCommand { get; private set; }
        public DelegateCommand ToPersonsSettingsCommand { get; private set; }
        public DelegateCommand ToProjectsSettingsCommand { get; private set; }
        IContainerProvider ContainerManager;
        IRegionManager RegionManager;
        public SettingsViewModel(IContainerProvider _containerManager, IRegionManager _regionManager)
        {
            BackToBootMenuCommand = new DelegateCommand(BackToBootMenu);
            ToPersonsSettingsCommand = new DelegateCommand(ToPersonsSettings);
            ToProjectsSettingsCommand = new DelegateCommand(ToProjectSettings);
            ContainerManager = _containerManager;
            RegionManager = _regionManager;
        }

        void BackToBootMenu()
        {
            RegionManager.RequestNavigate("ContentRegion", "BootMenu");
        }

        void ToPersonsSettings()
        {
            RegionManager.RequestNavigate("TabRegion", "PersonsSettings");
        }

        void ToProjectSettings()
        {
            RegionManager.RequestNavigate("TabRegion", "ProjectsSettings");
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
