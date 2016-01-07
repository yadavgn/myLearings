using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMProject.Infrastructure;

namespace myModels
{
    public class EmployeeManager: NotifyBase
    {
        public EmployeeManager()
        {
            _employees.CollectionChanged += CalculateAverageSalary;
        }
        
        public ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public void AddNewEmployee(Employee employee)
        {
            _employees.Add(employee);
            
        }

        public bool CanAddNewEmplyee(Employee emp)
        {
            if (emp.Salary > 30)
                return false;
            return true;
        }

        public bool CanDeleteSelectedEmployee(Employee emp)
        {
            if (emp == null) return false;

            if(emp.Name == "Kaushal" && emp.Last=="Kishore") return false;

            return true;
        }

        public void DeleteSelectedEmployee(Employee emp)
        {
            Employees.Remove(emp);
            
        }


        /// <summary>
        /// perform calculation on change of the collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CalculateAverageSalary(object sender, NotifyCollectionChangedEventArgs e)
        {
            //This will get called when the collection is changed
        }

        //public IList<Employee> getEmployee(Action act)
        //{
            
        //}
    }
}
