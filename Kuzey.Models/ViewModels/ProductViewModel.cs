using System;
using System.Collections.Generic;
using System.Text;
using Kuzey.Models.Entities;

namespace Kuzey.Models.ViewModels
{
    public class ProductViewModel : BaseEntity<string>
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
