using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
            CitizenoxVaccinations = new HashSet<CitizenoxVaccination>();
            Diseases = new HashSet<Disease>();
        }

        public string Dui { get; set; }
        public string Cname { get; set; }
        public int? Age { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int? IdEssentialInstitution { get; set; }

        public virtual EssentialInstitution IdEssentialInstitutionNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<CitizenoxVaccination> CitizenoxVaccinations { get; set; }
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
