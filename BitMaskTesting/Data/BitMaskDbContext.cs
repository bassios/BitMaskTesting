using BitMaskTesting.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BitMaskTesting.Data
{
    public class BitMaskDbContext : DbContext
    {
        public BitMaskDbContext(DbContextOptions<BitMaskDbContext> options) : base(options)
        {

        }

        public DbSet<DocumentCategory> DocumentCategories { get; set; }
        public DbSet<DocumentFormMask> DocumentFormMasks { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentCategory>().ToTable("DocumentCategory");
            modelBuilder.Entity<DocumentFormMask>().ToTable("DocumentFormMask");
            modelBuilder.Entity<DocumentType>().ToTable("DocumentType");
        }
    }

    public static class DbInitialiser
    {
        public static void Initialise(BitMaskDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.DocumentCategories.Any())
            {
                return; //DB has been seeded
            }

            var categories = new DocumentCategory[]
            {
                new DocumentCategory{Name="Category 1"},
                new DocumentCategory{Name="Category 2"}
            };

            foreach (var category in categories)
            {
                context.DocumentCategories.Add(category);
            }
            context.SaveChanges();

            var types = new DocumentType[]
            {
                new DocumentType{Name="Type 1", DocumentCategory=categories[0], FormMask=new byte[]{ 1 } },
                new DocumentType{Name="Type 2", DocumentCategory=categories[1], FormMask=new byte[]{ 2 } },
                new DocumentType{Name="Type 3", DocumentCategory=categories[0], FormMask=new byte[]{ 3 } }
            };

            foreach (var type in types)
            {
                context.DocumentTypes.Add(type);
            }

            context.SaveChanges();

            var masks = new DocumentFormMask[]
            {
                new DocumentFormMask{FormName= "Form 1", BitValue=1 },
                new DocumentFormMask{FormName= "Form 2", BitValue=2 },
            };

            foreach (var mask in masks)
            {
                context.DocumentFormMasks.Add(mask);
            }

            context.SaveChanges();
        }
    }
}
