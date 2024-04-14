using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Orders
    {
        [Key]
        [JsonPropertyName("order_id")]
        [Column("order_id")]

        public int OrderId { get; set; }

        [JsonPropertyName("status")]
        [Required]
        public string? Status { get; set; }

        [JsonPropertyName("order_date")]
        [Column("order_date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? OrderDate { get; set; }

        [ForeignKey("Customers")]
        [JsonPropertyName("customer_id")]
        [Column("customer_id")]
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("Employees")]
        [JsonPropertyName("salesman_id")]
        [Column("salesman_id")]
        public int SalesmanId { get; set; }

        public Customers? Customers { get; set; }
        public Employees? Employees { get; set; }
    }
}
