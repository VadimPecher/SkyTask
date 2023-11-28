using System.ComponentModel.DataAnnotations;

namespace SkyTask.Models
{
    public class Portfolio
    {
        [Key] 
        public Guid PortfolioId { get; set; }
        public Guid TenantId { get; set; }
        [Required]
        public string PortfolioName { get; set; } = string.Empty;

        public List<Plant> Plants { get; } = [];
    }
}
