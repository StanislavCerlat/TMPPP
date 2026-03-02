namespace DigitalLibraryManagementSystem.Models.Documents
{
    public class BookBuilder
    {
        private string _title;
        private string _author;

        public BookBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public BookBuilder SetAuthor(string author)
        {
            _author = author;
            return this;
        }

        public Book Build()
        {
            return new Book(_title, _author);
        }
    }
}