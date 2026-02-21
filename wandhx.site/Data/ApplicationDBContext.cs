using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Text.Json;
using WandhxSite.Models;

namespace WandhxSite.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<ExperieceModel> Experiences { get; set; }
        public DbSet<SkillModel> SkillCategories { get; set; }
        public DbSet<BlogModel> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Comparer for string arrays to ensure EF Core can track changes correctly
            var stringArrayComparer = new ValueComparer<string[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray());


            // Because EF Core does not natively support array types,
            // we need to convert the string arrays to JSON strings for storage in the database,
            // and back to string arrays when reading from the database.
            // We also set a custom ValueComparer to ensure that EF Core can correctly track changes to these properties.
            modelBuilder.Entity<ProjectModel>()
                .Property(p => p.Technologies)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<string[]>(v, (JsonSerializerOptions?)null) ?? Array.Empty<string>()
                )
                .Metadata.SetValueComparer(stringArrayComparer);

            // Similarly, we apply the same conversion and comparer for the Description property in ExperieceModel,
            modelBuilder.Entity<ExperieceModel>()
                .Property(e => e.Description)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<string[]>(v, (JsonSerializerOptions?)null) ?? Array.Empty<string>()
                )
                .Metadata.SetValueComparer(stringArrayComparer);

            // And for the Skills property in SkillModel.
            modelBuilder.Entity<SkillModel>()
                .Property(s => s.Skills)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<string[]>(v, (JsonSerializerOptions?)null) ?? Array.Empty<string>()
                )
                .Metadata.SetValueComparer(stringArrayComparer);
        }
    }
}