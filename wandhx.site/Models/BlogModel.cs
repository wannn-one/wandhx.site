using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WandhxSite.Models
{
    [Table("Blogs")]
    public class BlogModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [Column("slug")]
        public string Slug { get; set; } = string.Empty;

        [Required]
        [Column("content")]
        public string Content { get; set; } = string.Empty;

        [StringLength(500)]
        [Column("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }

        [Column("is_published")]
        public bool IsPublished { get; set; } = false;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
