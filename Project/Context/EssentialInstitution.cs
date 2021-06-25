using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class EssentialInstitution
    {
        public EssentialInstitution()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public string EssentialInstitution1 { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
