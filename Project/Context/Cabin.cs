using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class Cabin
    {
        public Cabin()
        {
            Managers = new HashSet<Manager>();
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}
