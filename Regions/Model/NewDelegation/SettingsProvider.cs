using Regions.Services;
using Regions.Services.NewDelegation;
using Regions.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.NewDelegation
{
 public   class SettingsProvider: IEmployees, IProjects, IEmployeesSaver, IProjectSaver
    {
        public IEnumerable<T> GetEmployees<T>()
        {

            IEnumerable<T> CollectionOfEmployees;
            CollectionOfEmployees = SettingsManager.Settings.Read<IEnumerable<T>>("employees");
            return CollectionOfEmployees;
        }

        public IEnumerable<T> GetProjects<T>()
        {
            IEnumerable<T> CollectionOfProjects;
            CollectionOfProjects = SettingsManager.Settings.Read<IEnumerable<T>>("projects");
            return CollectionOfProjects;
        }

        public void SaveEmployees<T>(T Employees)
        {
            SettingsManager.Settings.Write<T>(Employees, "employees");
        }

        public void SaveProject<T>(T Projects)
        {
            SettingsManager.Settings.Write<T>(Projects, "projects");
        }
    }
}
