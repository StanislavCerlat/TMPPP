using System;
using System.Collections.Generic;

namespace DigitalLibraryManagementSystem.Iterator
{
    public class LibraryBook
    {
        public string Title { get; }
        public string Author { get; }
        public string Genre { get; }

        public LibraryBook(string title, string author, string genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }

        public override string ToString() => $"{Title} — {Author} ({Genre})";
    }

    public interface IBookIterator
    {
        bool HasNext();
        LibraryBook Next();
    }

    public class BookShelf
    {
        private readonly List<LibraryBook> _books = new();

        public int Count => _books.Count;

        public void AddBook(LibraryBook book)
        {
            _books.Add(book);
        }

        public IBookIterator GetIterator()
        {
            return new BookIterator(_books);
        }

        public IBookIterator GetGenreIterator(string genre)
        {
            return new GenreBookIterator(_books, genre);
        }
    }

    public class BookIterator : IBookIterator
    {
        private readonly List<LibraryBook> _books;
        private int _index;

        public BookIterator(List<LibraryBook> books)
        {
            _books = books;
            _index = 0;
        }

        public bool HasNext() => _index < _books.Count;

        public LibraryBook Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more books.");
            }

            return _books[_index++];
        }
    }

    public class GenreBookIterator : IBookIterator
    {
        private readonly List<LibraryBook> _filtered;
        private int _index;

        public GenreBookIterator(List<LibraryBook> books, string genre)
        {
            _filtered = books.FindAll(b => string.Equals(b.Genre, genre, StringComparison.OrdinalIgnoreCase));
            _index = 0;
        }

        public bool HasNext() => _index < _filtered.Count;

        public LibraryBook Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more books in this genre.");
            }

            return _filtered[_index++];
        }
    }
}
