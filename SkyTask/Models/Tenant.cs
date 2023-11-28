using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace SkyTask.Models
{
    public class Tenant
    {
        [Key]
        public Guid TenantId { get; set; }
        [Required]
        public string TenantName { get; set; } = string.Empty;
        [Required]
        public string TenantCountry { get; set; } = string.Empty;

        public List<Portfolio> Portfolios { get; } = [];
    }
}
