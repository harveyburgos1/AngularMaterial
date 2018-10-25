using Day1Library1.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Library1.Departments
{
    public class Department
    {
        SubDepartment subDept = new SubDepartment();

        private class SubDepartment
        {
            Customer c = new Customer();
        }
    }
}
