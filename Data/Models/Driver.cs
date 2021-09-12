using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? RetireDate { get; set; }
        public int? CarId { get; set; }

        public Car Car { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}