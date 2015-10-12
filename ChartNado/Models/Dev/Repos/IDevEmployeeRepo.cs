namespace ChartNado.Models.Dev.Repos
{
    using System;
    using System.Collections.Generic;
    using Entities;

    public interface IDevEmployeeRepo
    {
        bool Add(DevEmployee employee);
        List<DevEmployee> GetAll();
        DevEmployee GetOne(Guid id);
        bool Remove(Guid id);
        bool Update(DevEmployee employee);
    }
}