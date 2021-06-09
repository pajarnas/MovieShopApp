using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    class PurchaseDateTime
    {
        public int UserId { get; set; }
        public string PurchaseNumber { get; set; }
        public double TotalPrice { get; set; }
        public int MovieId { get; set; }
    }
}
