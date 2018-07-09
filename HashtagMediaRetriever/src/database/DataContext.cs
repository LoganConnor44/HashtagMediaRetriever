using Microsoft.EntityFrameworkCore;
using HashtagMediaRetriever.src.products;

namespace HashtagMediaRetriever.database {
    public class DataContext : DbContext {
        public DbSet<Memento> Mementos { get; set; }
        public DbSet<Memory> Memories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Memento>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Memento>()
                .Property(x => x.Type)
                .IsRequired();
            modelBuilder.Entity<Memento>()
                .Property(x => x.Comment)
                .ValueGeneratedNever();
            modelBuilder.Entity<Memento>()
                .Property(x => x.Owner)
                .IsRequired();
            modelBuilder.Entity<Memento>()
                .Property(x => x.Memories);
            modelBuilder.Entity<Memento>()
                .Property(x => x.Creation)
                .IsRequired()
                .HasColumnType("datetime2");

            modelBuilder.Entity<Memory>()
                .HasOne(x => x.Memento)
                .WithMany(x => x.Memories)
                .HasForeignKey(x => x.MementoId);
        }
    }
}