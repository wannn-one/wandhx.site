using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WandhxSite.Models
{
    [Table("Skill")]
    public class SkillModel
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("skills")]
        public string[] Skills { get; set; } = [];

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
