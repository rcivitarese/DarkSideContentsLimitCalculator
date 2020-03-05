using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DSCLC.DataLayer
{
    public partial class DSCLCDBContext : DbContext
    {

        public DSCLCDBContext(DbContextOptions<DSCLCDBContext> options) : base(options)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder(options);
            OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<ContentItem> DbContentList { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\array\\source\\repos\\DarkSideContentsLimitCalculator\\Data\\DarkSideContentsLimitDB.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentItem>(entity =>
            {
                entity.HasKey(e => e.ContentItemId);

                entity.ToTable("RenterContents");

                entity.Property(e => e.ContentItemId);

                entity.Property(e => e.Value);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.CategoryName);
            });
        }

    }
}
