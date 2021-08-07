using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Regions.ViewModels
{
    public class BootMenuViewModel : BindableBase
    {
        IRegionManager RegionManager;
        public DelegateCommand NewDelegationCommand { get; private set; }

        public DelegateCommand SettingsCommand { get; private set; }
        public DelegateCommand CountDelegationCommand { get; private set; }
        public BootMenuViewModel(IRegionManager _regionManager)
        {
            RegionManager = _regionManager;
            NewDelegationCommand = new DelegateCommand(NavigateToNewDelegationView);
            SettingsCommand = new DelegateCommand(NavigateToSettingsView);
            CountDelegationCommand = new DelegateCommand(NavigateToCountDelegationView);
        }

        void NavigateToNewDelegationView()
        {
            RegionManager.RequestNavigate("ContentRegion", "NewDelegation");
        }

        void NavigateToSettingsView()
        {
            RegionManager.RequestNavigate("ContentRegion", "Settings");
        }

       void NavigateToCountDelegationView()
        {
            RegionManager.RequestNavigate("ContentRegion", "TravelExpenseBill");
        }
    }
}
