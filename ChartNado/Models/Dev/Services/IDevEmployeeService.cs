namespace ChartNado.Models.Dev.Services
{
    using System;
    using System.Collections.Generic;
    using Entities;

    public interface IDevEmployeeService
    {
        bool DeleteEmployee(Guid id);
        DevEmployee GetEmployeeByGuid(Guid id);
        List<DevEmployee> RetrieveEmployees();
        bool SaveEmployee(DevEmployee employee);
        bool UpdateEmployee(DevEmployee employee);
    }
}