using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Managers = new HashSet<Manager>();
        }

        public int Id { get; set; }
        public string TemployeeType { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}
