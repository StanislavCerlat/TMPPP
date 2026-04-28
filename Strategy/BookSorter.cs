using System.Collections.Generic;

namespace DigitalLibraryManagementSystem.Strategy
{
    public class BookSorter
    {
        private readonly ISortStrategy _strategy;

        public BookSorter(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<string> Sort(List<string> books)
        {
            return _strategy.Sort(books);
        }
    }
}
