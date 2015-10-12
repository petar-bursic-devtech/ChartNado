namespace ChartNado.Models.Dev.Repos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities;

    public class DevEmployeeRepo : IDevEmployeeRepo
    {
        private static List<DevEmployee> _employees = new List<DevEmployee>();

        public List<DevEmployee> GetAll()
        {
            return _employees;
        }

        public DevEmployee GetOne(Guid id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public bool Add(DevEmployee employee)
        {
            _employees.Add(employee);
            return true;
        }

        public bool Remove(Guid id)
        {
            _employees = _employees.Where(e => e.Id != id).ToList();
            return true;
        }

        public bool Update(DevEmployee employee)
        {
            var target = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (target == null)
            {
                return false;
            }

            target.Age = employee.Age;
            target.FirstName = employee.FirstName;
            target.LastName = employee.LastName;
            target.Salary = employee.Salary;

            return true;
        }
    }
}