﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Inventories
    {
        [JsonPropertyName("quantity")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Quantity { get; set; }

        [ForeignKey("Products")]
        [JsonPropertyName("product_id")]
        [Column("product_id")]
        [Required]
        public int ProductId { get; set; }

        [ForeignKey("Warehouses")]
        [JsonPropertyName("warehouse_id")]
        [Column("warehouse_id")]
        [Required]
        public int WarehouseId { get; set; }

        public Products? Products { get; set; }
        public Warehouses? Warehouses { get; set; }
    }
}
