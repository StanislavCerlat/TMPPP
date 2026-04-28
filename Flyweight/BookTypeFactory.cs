using System.Collections.Generic;

namespace DigitalLibraryManagementSystem.Flyweight
{
    public static class BookTypeFactory
    {
        private static readonly Dictionary<string, BookType> Cache = new();

        public static BookType GetBookType(string genre, string language)
        {
            string key = $"{genre}|{language}";
            if (!Cache.TryGetValue(key, out var type))
            {
                type = new BookType(genre, language);
                Cache[key] = type;
            }

            return type;
        }
    }
}
