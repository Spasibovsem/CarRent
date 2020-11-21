using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Mileage { get; set; }
        public int RepairPrice { get; set; }
        public DateTime RepairDate { get; set; }
        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
