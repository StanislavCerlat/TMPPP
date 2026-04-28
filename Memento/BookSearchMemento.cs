using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalLibraryManagementSystem.Memento
{
    public class BookSearchMemento
    {
        public string Query { get; }
        public string Filter { get; }
        public DateTime SavedAt { get; }

        public BookSearchMemento(string query, string filter)
        {
            Query = query;
            Filter = filter;
            SavedAt = DateTime.Now;
        }

        public override string ToString() => $"[{SavedAt:HH:mm:ss}] Query='{Query}', Filter='{Filter}'";
    }

    public class BookSearch
    {
        public string Query { get; set; } = string.Empty;
        public string Filter { get; set; } = string.Empty;

        public BookSearchMemento Save() => new(Query, Filter);

        public void Restore(BookSearchMemento memento)
        {
            Query = memento.Query;
            Filter = memento.Filter;
        }

        public void Search()
        {
            Console.WriteLine($"Search run: query='{Query}', filter='{Filter}'");
        }
    }

    public class SearchHistory
    {
        private readonly Stack<BookSearchMemento> _history = new();

        public int Count => _history.Count;

        public void Push(BookSearchMemento memento)
        {
            _history.Push(memento);
        }

        public BookSearchMemento? Pop()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("No search state to restore.");
                return null;
            }

            return _history.Pop();
        }

        public List<BookSearchMemento> GetAll()
        {
            return _history.Reverse().ToList();
        }
    }
}
