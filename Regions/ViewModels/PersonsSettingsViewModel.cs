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
using System.Windows;

namespace Regions.ViewModels
{
    public class PersonsSettingsViewModel : BindableBase, INavigationAware
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

        public DelegateCommand NewPersonCommand { get; private set; }
        public DelegateCommand DeletePersonCommand { get; private set; }
        public DelegateCommand SavePersonsCommand { get; private set; }
        IContainerProvider ContainerProvider;
        IRegionManager RegionManager;
        public PersonsSettingsViewModel(IContainerProvider _containerManager, IRegionManager _regionManager)
        {

            ContainerProvider = _containerManager;
            RegionManager = _regionManager;
            var EmployeesProvider = ContainerProvider.Resolve<IEmployees>();
            NewPersonCommand = new DelegateCommand(AddNewPerson);
            DeletePersonCommand = new DelegateCommand(DeletePerson);
            SavePersonsCommand = new DelegateCommand(SavePersons);
            Employees = new ObservableCollection<Employee>(EmployeesProvider.GetEmployees<Employee>().ToList());
        }

        void AddNewPerson()
        {
            Employees.Add(new Employee{ Name = "Nowe Imie", FirstName = "Nowe nazwisko", AcountNumber = "brak", Email = "brak" });
        }

        void DeletePerson()
        {
            Employees.Remove(SelectedEmployee);
        }

        void SavePersons()
        {
            var EmployeesProvider = ContainerProvider.Resolve<IEmployeesSaver>();
            EmployeesProvider.SaveEmployees<ObservableCollection<Employee>>(Employees);
           
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var EmployeesProvider = ContainerProvider.Resolve<IEmployees>();
            Employees = new ObservableCollection<Employee>(EmployeesProvider.GetEmployees<Employee>().ToList());
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
