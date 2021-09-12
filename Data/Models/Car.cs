using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int PurchasePrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        public ICollection<Repair> Repairs { get; set; }
        public Driver Driver { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
