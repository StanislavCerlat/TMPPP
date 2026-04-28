using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalLibraryManagementSystem.Strategy
{
    public class SortByTitleDescStrategy : ISortStrategy
    {
        public List<string> Sort(List<string> books)
        {
            return books.OrderByDescending(b => b, StringComparer.OrdinalIgnoreCase).ToList();
        }

        public string GetName() => "Sortare alfabetica inversa (Z-A)";
    }
}
