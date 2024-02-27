namespace DigitalLibraryManagementSystem.Models.Documents
{
    public abstract class Document
    {
        public string Title { get; }
        public string Author { get; }

        protected Document(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public abstract string GetDocumentType();
    }
}