namespace DigitalLibraryManagementSystem.Models.Documents
{
    public class BookBuilder
    {
        private string _title = "Untitled";
        private string _author = "Unknown";
        private string _genre = "Unknown";
        private int _pages = 0;
        private string _isbn = "Not specified";

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

        public BookBuilder SetGenre(string genre)
        {
            _genre = genre;
            return this;
        }

        public BookBuilder SetPages(int pages)
        {
            _pages = pages;
            return this;
        }

        public BookBuilder SetISBN(string isbn)
        {
            _isbn = isbn;
            return this;
        }

        public Book Build()
        {
            return new Book(_title, _author, _genre, _pages, _isbn);
        }
    }
}