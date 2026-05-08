namespace DigitalLibraryManagementSystem.Mediator
{
    // Interfata mediator
    public interface ILibraryMediator
    {
        void Notify(LibraryColleague sender, string eventType, string data);
    }

    // Clasa de baza pentru participanti
    public abstract class LibraryColleague
    {
        protected ILibraryMediator _mediator;
        public string Name { get; }

        protected LibraryColleague(string name, ILibraryMediator mediator)
        {
            Name      = name;
            _mediator = mediator;
        }
    }

    // Participanti concreti
    public class LibrarianColleague : LibraryColleague
    {
        public LibrarianColleague(ILibraryMediator med) : base("Bibliotecar", med) { }

        public void ProcessReturn(string book)
        {
            Console.WriteLine($"[{Name}] Proceseaza returnarea cartii: \"{book}\"");
            _mediator.Notify(this, "BookReturned", book);
        }

        public void ReceiveNotification(string msg) =>
            Console.WriteLine($"[{Name}] Notificare primita: {msg}");
    }

    public class StudentColleague : LibraryColleague
    {
        public StudentColleague(ILibraryMediator med) : base("Student", med) { }

        public void RequestBook(string book)
        {
            Console.WriteLine($"[{Name}] Solicita cartea: \"{book}\"");
            _mediator.Notify(this, "BookRequested", book);
        }

        public void ReceiveNotification(string msg) =>
            Console.WriteLine($"[{Name}] Notificare primita: {msg}");
    }

    public class CatalogColleague : LibraryColleague
    {
        public CatalogColleague(ILibraryMediator med) : base("Catalog", med) { }

        public void UpdateStock(string book, bool available)
        {
            string status = available ? "disponibila" : "indisponibila";
            Console.WriteLine($"[{Name}] Actualizeaza: \"{book}\" → {status}");
            _mediator.Notify(this, "StockUpdated", $"{book}:{available}");
        }

        public void ReceiveNotification(string msg) =>
            Console.WriteLine($"[{Name}] Catalog actualizat: {msg}");
    }

    // Mediatorul concret
    public class LibraryMediator : ILibraryMediator
    {
        public LibrarianColleague? Librarian { get; set; }
        public StudentColleague?  Student   { get; set; }
        public CatalogColleague?  Catalog   { get; set; }

        public void Notify(LibraryColleague sender, string eventType, string data)
        {
            Console.WriteLine($"\n[Mediator] Eveniment '{eventType}' de la {sender.Name}");
            switch (eventType)
            {
                case "BookReturned":
                    Catalog?.UpdateStock(data, true);
                    Student?.ReceiveNotification($"Cartea \"{data}\" este acum disponibila!");
                    break;
                case "BookRequested":
                    Librarian?.ReceiveNotification($"Studentul solicita \"{data}\".");
                    Catalog?.ReceiveNotification($"Rezervare pentru \"{data}\".");
                    break;
                case "StockUpdated":
                    Librarian?.ReceiveNotification($"Stoc actualizat: {data}");
                    break;
            }
        }
    }

    // Simple chat-style mediator used by UI Lab 7.
    public class LibraryChatMediator
    {
        private readonly List<LibraryUser> _users = new();

        public int UserCount => _users.Count;

        public void Register(LibraryUser user)
        {
            if (!_users.Contains(user))
            {
                _users.Add(user);
                Console.WriteLine($"[ChatMediator] Conectat: {user.Name}");
            }
        }

        public void Broadcast(string sender, string message)
        {
            foreach (var user in _users)
            {
                if (!string.Equals(user.Name, sender, StringComparison.OrdinalIgnoreCase))
                {
                    user.Receive(sender, message);
                }
            }
        }
    }

    public class LibraryUser
    {
        private readonly LibraryChatMediator _mediator;

        public string Name { get; }

        public LibraryUser(string name, LibraryChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
            _mediator.Register(this);
        }

        public void Send(string message)
        {
            Console.WriteLine($"[{Name}] trimite: {message}");
            _mediator.Broadcast(Name, message);
        }

        public void Receive(string from, string message)
        {
            Console.WriteLine($"  -> {Name} a primit de la {from}: {message}");
        }
    }
}