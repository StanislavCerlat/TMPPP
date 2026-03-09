using System;

namespace DigitalLibraryManagementSystem.Models.Documents
{
    public class Book : Document
    {
        public string Genre { get; }
        public int Pages { get; }
        public string ISBN { get; }

        public Book(string title, string author)
            : base(title, author)
        {
            Genre = "Unknown";
            Pages = 0;
            ISBN = "Not specified";
        }

        public Book(string title, string author, string genre, int pages, string isbn)
            : base(title, author)
        {
            Genre = genre;
            Pages = pages;
            ISBN = isbn;
        }

        public override string GetDocumentType()
        {
            return "Book";
        }

        public Book Clone()
        {
            return new Book(Title, Author, Genre, Pages, ISBN);
        }

        public void PrintBookInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Pages: {Pages}");
            Console.WriteLine($"ISBN: {ISBN}");
        }
    }
}