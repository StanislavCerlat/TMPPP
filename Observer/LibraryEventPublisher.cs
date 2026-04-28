using System.Collections.Generic;

namespace DigitalLibraryManagementSystem.Observer
{
    public class LibraryEventPublisher
    {
        private readonly List<ILibraryObserver> _observers = new();

        public void Subscribe(ILibraryObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(ILibraryObserver observer)
        {
            _observers.Remove(observer);
        }

        public void BookBorrowed(string bookTitle)
        {
            foreach (var observer in _observers)
            {
                observer.OnBookBorrowed(bookTitle);
            }
        }

        public void BookReturned(string bookTitle)
        {
            foreach (var observer in _observers)
            {
                observer.OnBookReturned(bookTitle);
            }
        }
    }
}
