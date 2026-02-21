using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WandhxSite.Models
{
    [Table("Projects")]
    public class ProjectModel
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("technologies")]
        public string[] Technologies { get; set; } = [];

        [StringLength(255)]
        [Column("image_url")]
        public string? ImageUrl { get; set; } = string.Empty;

        [StringLength(255)]
        [Column("project_url")]
        public string ImageUrls { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
