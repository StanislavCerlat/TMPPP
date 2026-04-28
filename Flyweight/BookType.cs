namespace DigitalLibraryManagementSystem.Flyweight
{
    public class BookType
    {
        public string Genre { get; }
        public string Language { get; }

        public BookType(string genre, string language)
        {
            Genre = genre;
            Language = language;
        }

        public override string ToString() => $"{Genre} ({Language})";
    }
}
