using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class Vaccination
    {
        public Vaccination()
        {
            CitizenxVaccinations = new HashSet<CitizenxVaccination>();
            SideEffects = new HashSet<SideEffect>();
        }

        public int Id { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public string Vaccinator { get; set; }
        public int? EffectTime { get; set; }

        public virtual ICollection<CitizenxVaccination> CitizenxVaccinations { get; set; }
        public virtual ICollection<SideEffect> SideEffects { get; set; }
    }
}
