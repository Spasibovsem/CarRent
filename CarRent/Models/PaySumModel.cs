using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;

namespace CarRent.Models
{
    public class PaySumModel
    {
        public string CarName { get; set; }
        public string DriverName { get; set; }
        public int PaymentSum { get; set; }
    }
}
