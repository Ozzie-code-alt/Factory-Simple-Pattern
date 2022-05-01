using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Managers;

namespace Web.Factory
{
    public class EmployeeManagerFactory
    {
        public IEmployeeManagers GetEmployeeManager(int employeeTypeId)
        {
            IEmployeeManagers returnvalue = null;
            if(employeeTypeId == 1)
            {
                returnvalue = new FulltimeEmployees();
            }
            else if (employeeTypeId == 2)
            {
                returnvalue = new PartTimeEMployees();
            }
            return returnvalue;
        }
    }
}