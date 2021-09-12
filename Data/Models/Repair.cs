using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Mileage { get; set; }
        public int RepairPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime RepairDate { get; set; }
        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
