namespace ChartNado.Models.Dev.Entities
{
    using System;

    public class DevEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}