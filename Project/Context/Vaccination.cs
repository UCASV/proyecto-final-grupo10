using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class Vaccination
    {
        public Vaccination()
        {
            CitizenoxVaccinations = new HashSet<CitizenoxVaccination>();
        }

        public int Id { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public string Vaccinator { get; set; }
        public int? EffectTime { get; set; }

        public virtual ICollection<CitizenoxVaccination> CitizenoxVaccinations { get; set; }
    }
}
