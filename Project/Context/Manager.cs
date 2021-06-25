using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class Manager
    {
        public Manager()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string ManagerUser { get; set; }
        public string Mpassword { get; set; }
        public int? IdEmployeeType { get; set; }
        public string Email { get; set; }
        public string HomeAdress { get; set; }
        public int? IdCabin { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual EmployeeType IdEmployeeTypeNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
