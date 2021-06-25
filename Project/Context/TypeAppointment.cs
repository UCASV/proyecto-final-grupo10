using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class TypeAppointment
    {
        public TypeAppointment()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string TypeAppointment1 { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
