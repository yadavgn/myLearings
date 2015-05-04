using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myModels;

namespace Business
{
    public class EmpBusinessCase
    {
        public static bool CanAddEmployee(Employee emp)
        {
            if (emp == null || string.IsNullOrEmpty(emp.Name) || string.IsNullOrEmpty(emp.Last)) return false;
            
            if (emp.Name == "Kaushal" && emp.Last == "Kishore") return true;

            if (emp.Salary > 30) return false;

            return true;
        }

    }
}
