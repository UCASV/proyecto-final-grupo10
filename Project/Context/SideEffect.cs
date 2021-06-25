using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class SideEffect
    {
        public string SideEffects { get; set; }
        public int? VaccinationId { get; set; }

        public virtual Vaccination Vaccination { get; set; }
    }
}
