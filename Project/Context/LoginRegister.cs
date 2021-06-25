using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Context
{
    public partial class LoginRegister
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
        public string CabinAdress { get; set; }
        public string CabinEmail { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
