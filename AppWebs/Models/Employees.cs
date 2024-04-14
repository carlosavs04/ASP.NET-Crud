using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Employees
    {
        [Key]
        [JsonPropertyName("employee_id")]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("first_name")]
        [Column("first_name")]
        [Required]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        [Column("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("email")]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [JsonPropertyName("phone")]
        [MaxLength(20)]
        [Required]
        public string? Phone { get; set; }

        [JsonPropertyName("hire_date")]
        [Column("hire_date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime HireDate { get; set; }

        [JsonPropertyName("job_title")]
        [Column("job_title")]
        [Required]
        public string? JobTitle { get; set; }
    }
}
