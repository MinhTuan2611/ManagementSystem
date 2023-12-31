﻿using ManagementSystem.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Common.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string? BarCode { get; set; }
        public string ProductName { get; set; }
        public string? Decription { get; set; }
        public int? CategoryId { get; set; }
        public ProductTypes ProductType { get; set; } = ProductTypes.Product;
        public int Price { get; set; }
        public int? Tax { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
        public int DefaultPurchasePrice { get; set; }

        public int? CreditAccountId { get; set; }
        public int? DebitAccountId { get; set; }
        public int? RevenueGroupId { get; set; }

        public string? ProductUnSignSearching { get; set; }
        public Category? Category { get; set; }
        public RevenueGroup RevenueGroup { get; set; }
        public List<RequestSampleItem> RequestSampleItems { get; set; }
    }
}
