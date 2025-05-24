using System.ComponentModel.DataAnnotations;

namespace Walks.API.Models.DTO
{
    public class RegionRequestDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
