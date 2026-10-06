using System;

namespace BookstoreSystem.Models
{
    /*
     * =========================================================================
     * Part A — Mapping by Convention Questions & Answers:
     * =========================================================================
     * 
     * Q1: Why did the property "Id" become a Primary Key without any explicit configuration?
     * Answer:
     * EF Core follows the "Convention over Configuration" principle (Default Behavior).
     * By convention, any public property named "Id" or "<ClassName>Id" (e.g., "BookId"),
     * case-insensitive, is automatically mapped as the Primary Key of the table.
     * Furthermore, because "Id" is an integer (numeric), EF Core automatically configures
     * it as an Identity column: IDENTITY(1, 1).
     *
     * Q2: Why is "Country" nullable in the database while "Price" is not?
     * Answer:
     * This behavior is determined by C# type system rules and how EF Core interprets them:
     * 1) "Price" is of type 'decimal', which is a non-nullable Value Type in .NET.
     *    A value type cannot hold null by default, so EF Core by convention maps it 
     *    to a 'NOT NULL' column in SQL Server.
     * 2) "Country" is of type 'string', which is a Reference Type in C#.
     *    Reference types can naturally hold null values, so EF Core by convention maps 
     *    it to a nullable column (allowing NULL) in SQL Server unless explicitly constrained.
     * =========================================================================
     */
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
