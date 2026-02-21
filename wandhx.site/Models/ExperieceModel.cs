using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WandhxSite.Models
{
    [Table("Experience")]
    public class ExperieceModel
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
        [Column("company")]
        public string Company { get; set; }  = string.Empty;

        [Required]
        [StringLength(255)]
        [Column("period")]
        public string Period { get; set; } = string.Empty;

        [Required]
        [Column("description")]
        public string[] Description { get; set; } = [];

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
