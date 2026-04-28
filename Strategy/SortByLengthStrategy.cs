using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalLibraryManagementSystem.Strategy
{
    public class SortByLengthStrategy : ISortStrategy
    {
        public List<string> Sort(List<string> books)
        {
            return books
                .OrderBy(b => b.Length)
                .ThenBy(b => b, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public string GetName() => "Sortare dupa lungime";
    }
}
