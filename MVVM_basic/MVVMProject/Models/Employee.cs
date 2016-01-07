using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMProject.Infrastructure;

namespace myModels
{
    public class Employee : NotifyBase
    {
        private String _name;
        public String Name { get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private String _lastname;
        public String Last
        {
            get { return _lastname; }
            set
            {
                if(_lastname == value) return;
                _lastname = value;
                OnPropertyChanged();
            }
        }

        private double _salary;
        public double   Salary
        {
            get { return _salary; }
            set
            {
                if (Math.Abs(_salary - value) < 0.01) return;
                _salary = value;
                OnPropertyChanged();
            }
        }

        public Employee(string name, string last, double experiance)
        {
            Name = name;
            Last = last;
            Salary = experiance;
        }
    }
}
