using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalLibraryManagementSystem.Strategy
{
    public class SortByTitleStrategy : ISortStrategy
    {
        public List<string> Sort(List<string> books)
        {
            return books.OrderBy(b => b, StringComparer.OrdinalIgnoreCase).ToList();
        }

        public string GetName() => "Sortare alfabetica (A-Z)";
    }
}
