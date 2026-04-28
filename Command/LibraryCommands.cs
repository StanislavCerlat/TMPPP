using System;
using System.Collections.Generic;

namespace DigitalLibraryManagementSystem.Command
{
    public class BookCollection
    {
        public List<string> Books { get; } = new();

        public void AddBook(string title)
        {
            if (!string.IsNullOrWhiteSpace(title) && !Books.Contains(title))
            {
                Books.Add(title);
            }
        }

        public bool RemoveBook(string title)
        {
            return Books.Remove(title);
        }
    }

    public class AddBookCommand : ICommand
    {
        private readonly BookCollection _collection;
        private readonly string _title;

        public AddBookCommand(BookCollection collection, string title)
        {
            _collection = collection;
            _title = title;
        }

        public string Name => $"Add '{_title}'";

        public void Execute()
        {
            _collection.AddBook(_title);
            Console.WriteLine($"[COMMAND] Added: {_title}");
        }

        public void Undo()
        {
            _collection.RemoveBook(_title);
            Console.WriteLine($"[UNDO] Removed: {_title}");
        }
    }

    public class RemoveBookCommand : ICommand
    {
        private readonly BookCollection _collection;
        private readonly string _title;
        private bool _removed;

        public RemoveBookCommand(BookCollection collection, string title)
        {
            _collection = collection;
            _title = title;
        }

        public string Name => $"Remove '{_title}'";

        public void Execute()
        {
            _removed = _collection.RemoveBook(_title);
            Console.WriteLine(_removed
                ? $"[COMMAND] Removed: {_title}"
                : $"[COMMAND] Book not found: {_title}");
        }

        public void Undo()
        {
            if (_removed)
            {
                _collection.AddBook(_title);
                Console.WriteLine($"[UNDO] Re-added: {_title}");
            }
        }
    }

    public class LibraryCommandManager
    {
        private readonly Stack<ICommand> _undo = new();
        private readonly Stack<ICommand> _redo = new();

        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        public void Undo()
        {
            if (_undo.Count == 0)
            {
                Console.WriteLine("[UNDO] Nothing to undo.");
                return;
            }

            var command = _undo.Pop();
            command.Undo();
            _redo.Push(command);
        }

        public void Redo()
        {
            if (_redo.Count == 0)
            {
                Console.WriteLine("[REDO] Nothing to redo.");
                return;
            }

            var command = _redo.Pop();
            command.Execute();
            _undo.Push(command);
        }
    }
}
