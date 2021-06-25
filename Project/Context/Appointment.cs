using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string Place { get; set; }
        public int? IdTypeAppointment { get; set; }
        public int? IdManager { get; set; }
        public string IdCitizen { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
        public virtual Manager IdManagerNavigation { get; set; }
        public virtual TypeAppointment IdTypeAppointmentNavigation { get; set; }
    }
}
