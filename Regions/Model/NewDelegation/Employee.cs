using Regions.Services;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.NewDelegation
{
    public class Employee: IEmployeeEditor
    {
        public Employee()
        {

            FirstName = "Nazwisko";
            Name = "Imie";
            AcountNumber = "01011010";
            Email = "some@mail.pl";
        }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string AcountNumber { get; set; }
        public string Email { get; set; }

        public void Edit(string Firstname, string Name, string email, string acount)
        {
            this.Name = Name;
            this.FirstName = Firstname;
            AcountNumber = acount;
            Email = email;
        }

    }
}
