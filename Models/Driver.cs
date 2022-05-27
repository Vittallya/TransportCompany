using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// Водитель
    /// </summary>
    public class Driver
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DriverCategory DriverCategory { get; set; }
        public bool IsDriverFree { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

    }


    public enum DriverCategory
    {
        A, A1, B, BE, B1, C, CE, C1, C1E, D, DE, D1, D1E, M, Tm, Tb
    }
}
