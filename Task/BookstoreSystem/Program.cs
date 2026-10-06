using System;
using BookstoreSystem.Contexts;

namespace BookstoreSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("   Bookstore System - EF Core Code First Lab     ");
            Console.WriteLine("=================================================");
            Console.WriteLine();

            // Creating an instance of our DbContext
            using (var context = new BookstoreDbContext())
            {
                Console.WriteLine(">> BookstoreDbContext initialized successfully.");
                Console.WriteLine(">> Target Database: BookstoreDB (SQL Server)");
                Console.WriteLine();
                Console.WriteLine("Mapped Entities & Strategies:");
                Console.WriteLine("1. Book Entity:");
                Console.WriteLine("   - Configured via: Fluent API (BookConfigurations)");
                Console.WriteLine("   - Table: Books");
                Console.WriteLine("   - Title: Required, MaxLength 150");
                Console.WriteLine("   - Price: decimal(8,2), Required");
                Console.WriteLine("   - PublishedDate: Optional (datetime2, null)");
                Console.WriteLine();
                Console.WriteLine("2. Author Entity:");
                Console.WriteLine("   - Configured via: Data Annotations");
                Console.WriteLine("   - Table: Writers [Table(\"Writers\")]");
                Console.WriteLine("   - Name: Required, MaxLength 100 [Required, MaxLength(100)]");
                Console.WriteLine("   - Country: Optional (nvarchar(max), null)");
                Console.WriteLine();
                Console.WriteLine(">> All 3 Migrations created:");
                Console.WriteLine("   1) InitialCreate");
                Console.WriteLine("   2) AnnotateAuthor");
                Console.WriteLine("   3) FluentBook");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
        }
    }
}
