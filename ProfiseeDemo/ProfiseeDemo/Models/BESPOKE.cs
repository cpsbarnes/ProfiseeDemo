using System.ComponentModel.DataAnnotations;
using System;

namespace ProfiseeDemo.Models
{
    
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        public string? Style { get; set; }

        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        public int CommissionPercentage { get; set; }
    }

    public class SalesPerson
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public string? Phone { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TermDate { get; set; }

        public string? Manager { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public string? Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
    }

    public class Sales
    {
        public int Id { get; set; }
        public string? Product { get; set; }
        public string? SalesPerson { get; set; }
        public string? Customer{ get; set; }

        [DataType(DataType.Date)]
        public DateTime SalesDate { get; set; }
        public decimal SalePrice { get; set; }
        public decimal SalesCommission { get; set; }
    }

    public class Discount
    {
        public int Id { get; set; }
        public string? PRODUCT { get; set; }
        public string? Customer { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set;  }

        public int DiscountPercentage { get; set; }
    }
}
