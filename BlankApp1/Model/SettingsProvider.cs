using Regions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model
{
 public   class SettingsProvider: IEmployees, IProjects
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
    }
}
