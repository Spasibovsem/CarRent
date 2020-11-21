using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public int PaySum { get; set; }
        public DateTime PayDate { get; set; }

        public Car Car { get; set; }
        public Driver Driver { get; set; }
    }
}
