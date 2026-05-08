using System;

namespace DigitalLibraryManagementSystem.Visitor
{
    public interface IDocumentVisitor
    {
        string GetVisitorName();
        void VisitBook(VisitableBook book);
        void VisitMagazine(VisitableMagazine magazine);
        void VisitThesis(VisitableThesis thesis);
    }

    public interface IVisitableDocument
    {
        void Accept(IDocumentVisitor visitor);
    }

    public class VisitableBook : IVisitableDocument
    {
        public string Title { get; }
        public string Author { get; }
        public int Pages { get; }

        public VisitableBook(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
        }

        public void Accept(IDocumentVisitor visitor) => visitor.VisitBook(this);
    }

    public class VisitableMagazine : IVisitableDocument
    {
        public string Title { get; }
        public string Publisher { get; }
        public int Issue { get; }

        public VisitableMagazine(string title, string publisher, int issue)
        {
            Title = title;
            Publisher = publisher;
            Issue = issue;
        }

        public void Accept(IDocumentVisitor visitor) => visitor.VisitMagazine(this);
    }

    public class VisitableThesis : IVisitableDocument
    {
        public string Title { get; }
        public string Student { get; }
        public string University { get; }

        public VisitableThesis(string title, string student, string university)
        {
            Title = title;
            Student = student;
            University = university;
        }

        public void Accept(IDocumentVisitor visitor) => visitor.VisitThesis(this);
    }

    public class PdfExportVisitor : IDocumentVisitor
    {
        public string GetVisitorName() => "PDF";

        public void VisitBook(VisitableBook book)
        {
            Console.WriteLine($"[PDF] Export carte: {book.Title} ({book.Author}, {book.Pages} pagini)");
        }

        public void VisitMagazine(VisitableMagazine magazine)
        {
            Console.WriteLine($"[PDF] Export revista: {magazine.Title} (Issue {magazine.Issue}, {magazine.Publisher})");
        }

        public void VisitThesis(VisitableThesis thesis)
        {
            Console.WriteLine($"[PDF] Export teza: {thesis.Title} ({thesis.Student}, {thesis.University})");
        }
    }

    public class CsvExportVisitor : IDocumentVisitor
    {
        public string GetVisitorName() => "CSV";

        public void VisitBook(VisitableBook book)
        {
            Console.WriteLine($"[CSV] BOOK,{book.Title},{book.Author},{book.Pages}");
        }

        public void VisitMagazine(VisitableMagazine magazine)
        {
            Console.WriteLine($"[CSV] MAGAZINE,{magazine.Title},{magazine.Publisher},{magazine.Issue}");
        }

        public void VisitThesis(VisitableThesis thesis)
        {
            Console.WriteLine($"[CSV] THESIS,{thesis.Title},{thesis.Student},{thesis.University}");
        }
    }

    public class XmlExportVisitor : IDocumentVisitor
    {
        public string GetVisitorName() => "XML";

        public void VisitBook(VisitableBook book)
        {
            Console.WriteLine($"<book title=\"{book.Title}\" author=\"{book.Author}\" pages=\"{book.Pages}\" />");
        }

        public void VisitMagazine(VisitableMagazine magazine)
        {
            Console.WriteLine($"<magazine title=\"{magazine.Title}\" publisher=\"{magazine.Publisher}\" issue=\"{magazine.Issue}\" />");
        }

        public void VisitThesis(VisitableThesis thesis)
        {
            Console.WriteLine($"<thesis title=\"{thesis.Title}\" student=\"{thesis.Student}\" university=\"{thesis.University}\" />");
        }
    }
}
