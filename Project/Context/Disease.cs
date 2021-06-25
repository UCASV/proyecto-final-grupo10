using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class Disease
    {
        public int Id { get; set; }
        public string Disease1 { get; set; }
        public string IdCitizen { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
    }
}
