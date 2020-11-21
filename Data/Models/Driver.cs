using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? RetireDate { get; set; }
        public int? CarId { get; set; }

        public Car Car { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}