using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Regions.Model.NewDelegation;
using Regions.Services.NewDelegation;
using Regions.Services.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Regions.ViewModels
{
    public class ProjectsSettingsViewModel : BindableBase, INavigationAware
    {
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
        public DelegateCommand NewProjectCommand { get; private set; }
        public DelegateCommand DeleteProjectCommand { get; private set; }
        public DelegateCommand SaveProjectCommand { get; private set; }
        IContainerProvider ContainerProvider;
        IRegionManager RegionManager;
        public ProjectsSettingsViewModel(IContainerProvider _containerManager, IRegionManager _regionManager)
        {
            ContainerProvider = _containerManager;
            RegionManager = _regionManager;
            NewProjectCommand = new DelegateCommand(AddNewProject);
            DeleteProjectCommand = new DelegateCommand(DeleteProject);
            SaveProjectCommand = new DelegateCommand(SaveProjects);
        }

        void AddNewProject()
        {
            Projects.Add(new Project{ ProjectName = "Nowy", ProjectNumber = "TUT...", Company = "Firma", City="Miasto" });
        }
        void DeleteProject()
        {
            Projects.Remove(SelectedProject);
        }
        void SaveProjects()
        {
            var ProjectsController = ContainerProvider.Resolve<IProjectSaver>();
            ProjectsController.SaveProject<ObservableCollection<Project>>(Projects);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var ProjectsProvider = ContainerProvider.Resolve<IProjects>();
            Projects = new ObservableCollection<Project>(ProjectsProvider.GetProjects<Project>().ToList());
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
