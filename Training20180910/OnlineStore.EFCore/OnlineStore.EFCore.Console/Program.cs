using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using OnlineStore.EFCore.Infra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.EFCore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new OnlineStoreDbContext();
            IDepartmentRepository deptRepo =
                new DepartmentRepository(context);

            #region Create Record
            var tmg = new Department
            {
                DepartmentID = Guid.NewGuid(),
                DepartmentName = "Technology Management",
                IsActive = true
            };
            var bdg = new Department
            {
                DepartmentID = Guid.NewGuid(),
                DepartmentName = "Business Development",
                IsActive = true
            };

            deptRepo.Create(tmg);
            deptRepo.Create(bdg);

            var john = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "John",
                MiddleName = "C",
                LastName = "Fajardo",
                Department = bdg

            };
            var jervie = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "Jervie",
                MiddleName = "C",
                LastName = "Vitriolo",
                Department = tmg

            };

            IEmployeeRepository empRepo =
                new EmployeeRepository(context);
            empRepo.Create(jervie);
            empRepo.Create(john);

            #endregion

            #region Delete Record
            var arup = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "Arup",
                MiddleName = "C",
                LastName = "Maity",
                Department = tmg

            };
            empRepo.Create(arup);


            empRepo.Delete(arup.EmployeeID);

            #endregion

            #region Update Record
            var benjoe = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "Ben",
                MiddleName = "C",
                LastName = "Guevarra",
                Department = bdg

            };

            empRepo.Create(benjoe);

            benjoe.MiddleName = "De Jesus";
            empRepo.Update(benjoe.EmployeeID, benjoe);
            #endregion

            #region Retrieve Records
            var departments = deptRepo.Retrieve()
                            .Skip(40).Take(40).ToList();

           
            var tmgEmployees = from e in context.Employees
                               join d in context.Departments
                               on e.DepartmentID equals d.DepartmentID
                               where d.DepartmentName.Equals("Technology Management")
                               orderby e.LastName 
                               select new
                               {
                                   FullName = e.FirstName + " " +
                                             e.MiddleName.Substring(0, 1) + ". " +
                                             e.LastName,
                                   Department = d.DepartmentName
                               };
                              
     
            var result = tmgEmployees.ToList();

            #endregion

            context.Dispose();


        }
    }
}
