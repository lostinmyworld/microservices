using Api.Data.EfCore.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.RepositoryTests.MockData
{
    internal static class EmployeeData
    {
        private static List<Employee> _employees;

        internal static List<Employee> Employees
        {
            get
            {
                if (_employees == null || !_employees.Any())
                {
                    _employees = new List<Employee>
                    {
                        CreateEmployee1(),
                        CreateEmployee2()
                    };
                }

                return _employees;
            }
        }

        private static Employee CreateEmployee1()
        {
            return new Employee
            {
                Id = 1,
                FirstName = "Παναγιώρης",
                LastName = "Κατσιμπέρης",
                FathersName = "Χρήστος",
                BirthDate = new DateTime(1990, 10, 20),
                Phone = "+306971234567",
                Email = "example@example.com"
            };
        }

        private static Employee CreateEmployee2()
        {
            return new Employee
            {
                Id = 2,
                FirstName = "Fosia",
                LastName = "Sofia",
                FathersName = "X-zibit",
                BirthDate = new DateTime(1990, 10, 3),
                Phone = "+306977654321",
                Email = "test@test.com"
            };
        }
    }
}
