using System;
using System.Collections.Generic;

#nullable disable

namespace ServerApp1.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public int CityFrom { get; set; }
        public int CityTo { get; set; }
        public int Cost { get; set; }
    }
}
