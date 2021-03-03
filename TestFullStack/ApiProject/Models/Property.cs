using PropertyManagementAPI.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Models
{
    public class Property
    {
        [Key()]
        public int Id { get; set; }
        public string Address { get; set; }
        public int YearBuilt { get; set; }

        [DecimalPrecision(10, 2)]
        public decimal ListPrice { get; set; }
        [DecimalPrecision(10, 2)]
        public decimal MonthlyRent { get; set; }
        [DecimalPrecision(10, 2)]
        public decimal GrossYield { get; set; }
    }
}
