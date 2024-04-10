using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace backendtask.Model
{
    public class Product
    {
        public int ProductID {get; set;}
        public string? ProductName {get; set; }
        public string? country {get; set; }
        public string? InvoicePeriod {get; set; }
        public string? ScrapType {get; set; }
        public int ManCost {get; set; }
        public int MaterialCost {get; set; }
        public int EstimateCost {get; set; }
        public int LocalAmount {get; set; }
        public string? Image {get; set; }
    }
}