using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ujjal.ViewModel;

namespace Ujjal
{
    public class TabModel : ViewModelBase
    {
        private List<Department> departments;

        private string _name;

        public TabModel()
        {
            Name = "arocks";
            Departments = new List<Department>()
            {
                new Department("DotNet"),
                new Department("PHP")
            };
        }

        public List<Department> Departments
        {
            get
            {
                return departments;
            }
            set
            {
                departments = value;
                OnPropertyChanged("Departments");
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
