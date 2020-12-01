using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class RepairModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Mileage { get; set; }
        public int RepairPrice { get; set; }
        public DateTime RepairDate { get; set; }
    }
}
