namespace ChartNado.Models.Dev.Services
{
    using System;
    using System.Collections.Generic;
    using Entities;
    using Repos;

    public class DevEmployeeService : IDevEmployeeService
    {
        private readonly IDevEmployeeRepo _devEmployeeRepo;

        public DevEmployeeService(IDevEmployeeRepo devEmployeeRepo)
        {
            _devEmployeeRepo = devEmployeeRepo;
        }

        public bool SaveEmployee(DevEmployee employee)
        {
            return _devEmployeeRepo.Add(employee);
        }

        public List<DevEmployee> RetrieveEmployees()
        {
            return _devEmployeeRepo.GetAll();
        }

        public DevEmployee GetEmployeeByGuid(Guid id)
        {
            return _devEmployeeRepo.GetOne(id);
        }

        public bool DeleteEmployee(Guid id)
        {
            return _devEmployeeRepo.Remove(id);
        }

        public bool UpdateEmployee(DevEmployee employee)
        {
            return _devEmployeeRepo.Update(employee);
        }
    }
}