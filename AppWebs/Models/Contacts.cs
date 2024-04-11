using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Contacts
    {
        [Key]
        [JsonPropertyName("contact_id")]
        [Column("contact_id")]
        public int ContactId { get; set; }

        [JsonPropertyName("first_name")]
        [Column("first_name")]
        [Required]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        [Column("last_name")]
        [Required]
        public string? LastName { get; set; }

        [JsonPropertyName("email")]
        [Required]
        public string? Email { get; set; }

        [JsonPropertyName("phone")]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [ForeignKey("Customers")]
        [JsonPropertyName("customer_id")]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }
    }
}
