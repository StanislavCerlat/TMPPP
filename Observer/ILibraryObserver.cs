namespace DigitalLibraryManagementSystem.Observer
{
    public interface ILibraryObserver
    {
        void OnBookBorrowed(string bookTitle);
        void OnBookReturned(string bookTitle);
    }
}
