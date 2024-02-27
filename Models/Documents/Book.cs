namespace DigitalLibraryManagementSystem.Models.Documents
{
    public class Book : Document
    {
        public Book(string title, string author)
            : base(title, author)
        {
        }

        public override string GetDocumentType()
        {
            return "Book";
        }
    }
}