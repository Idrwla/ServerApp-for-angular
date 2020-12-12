using System;
using System.Collections.Generic;

#nullable disable

namespace ServerApp1.Models
{
    public partial class Partner
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string Bin { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int? BankId { get; set; }
    }
}
