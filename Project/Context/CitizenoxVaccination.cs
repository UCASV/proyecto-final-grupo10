using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class CitizenoxVaccination
    {
        public int Id { get; set; }
        public string CitizenId { get; set; }
        public int? VaccinationId { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual Vaccination Vaccination { get; set; }
    }
}
