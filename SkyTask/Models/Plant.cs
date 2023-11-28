using System.ComponentModel.DataAnnotations;

namespace SkyTask.Models
{
    public class Plant
    {
        [Key]
        public Guid PlantId { get; set; }
        public Guid PortfolioId { get; set; }
        [Required]
        public string PlantName { get; set; } = string.Empty;
    }
}
