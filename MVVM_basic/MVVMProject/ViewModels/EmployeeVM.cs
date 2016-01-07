using System.Collections.ObjectModel;
using System.Windows.Input;
using Business;
using MVVMProject.Infrastructure;
using myModels;

namespace MVVMProject.ViewModels
{
    public class EmployeeVM : NotifyBase
    {
        public EmployeeVM()
        {
            //SelectedEmp = new Employee("Rajeev", "Panda", 10);
            _empManager.AddNewEmployee(new Employee("Rajeev", "Panda", 10));
            _empManager.AddNewEmployee(new Employee("Kaushal", "Kishore", 10));
            SelectedEmployee = _empManager.Employees[0];
            _newEmp = new Employee("","",0);
        }
        
        public EmployeeManager EpmManager
        {
            get { return _empManager; }
        }

        private readonly EmployeeManager _empManager = new EmployeeManager();

        public ObservableCollection<Employee> EmpList
        {
            get { return _empManager.Employees; }
            private set
            {
                 // Do nothing.
            }
        }

        private Employee _newEmp;

        public Employee NewEmployee
        {
            get { return _newEmp; }
            set
            {
                if (value != null && _newEmp == value) return;
                _newEmp = value;
                OnPropertyChanged();
            }
        }

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private bool CanAddNewEmployee()
        {
            return EmpBusinessCase.CanAddEmployee(_newEmp);
        }

        private void AddEmployee()
        {
            _empManager.AddNewEmployee(_newEmp);
            
            NewEmployee = new Employee("","",0);
            
        }
        public ICommand AddNewEmployee
        {
            get
            {
                return new RelayCommand(AddEmployee, CanAddNewEmployee);
            }
        }


        public ICommand DeleteEmployee
        {
            get
            {
                return new RelayCommand(DeleteSelectedEmployee, CanDeleteSelectedEmployee);
            }
        }

        private bool CanDeleteSelectedEmployee()
        {
            
            return _empManager.CanDeleteSelectedEmployee(SelectedEmployee);
        }

        private void DeleteSelectedEmployee()
        {
            EpmManager.DeleteSelectedEmployee(SelectedEmployee);
            //SelectedEmployee = EpmManager.Employees[0];
        }

        public double AvgSalary()
        {
            return 1.0;
        }




    }
}
