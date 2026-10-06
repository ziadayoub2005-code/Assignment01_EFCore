using BookstoreSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreSystem.Configurations
{
    // Part C — Fluent API: Configuration Class Per Entity
    // Using IEntityTypeConfiguration<T> for Separation of Concerns and Clean POCO
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Title: Required, Max Length 150
            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            // Price: Column Type decimal(8,2)
            builder.Property(b => b.Price)
                   .HasColumnType("decimal(8,2)");

            // PublishedDate: Explicitly Optional
            builder.Property(b => b.PublishedDate)
                   .IsRequired(false);
        }
    }
}
