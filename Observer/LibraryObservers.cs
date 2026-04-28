using System;

namespace DigitalLibraryManagementSystem.Observer
{
    public class EmailNotifier : ILibraryObserver
    {
        private readonly string _email;

        public EmailNotifier(string email)
        {
            _email = email;
        }

        public void OnBookBorrowed(string bookTitle)
        {
            Console.WriteLine($"[EMAIL -> {_email}] Cartea '{bookTitle}' a fost imprumutata.");
        }

        public void OnBookReturned(string bookTitle)
        {
            Console.WriteLine($"[EMAIL -> {_email}] Cartea '{bookTitle}' a fost returnata.");
        }
    }

    public class SmsNotifier : ILibraryObserver
    {
        private readonly string _phone;

        public SmsNotifier(string phone)
        {
            _phone = phone;
        }

        public void OnBookBorrowed(string bookTitle)
        {
            Console.WriteLine($"[SMS -> {_phone}] Imprumut confirmat pentru '{bookTitle}'.");
        }

        public void OnBookReturned(string bookTitle)
        {
            Console.WriteLine($"[SMS -> {_phone}] Returnare confirmata pentru '{bookTitle}'.");
        }
    }

    public class DashboardNotifier : ILibraryObserver
    {
        public void OnBookBorrowed(string bookTitle)
        {
            Console.WriteLine($"[DASHBOARD] '{bookTitle}' este marcat ca imprumutat.");
        }

        public void OnBookReturned(string bookTitle)
        {
            Console.WriteLine($"[DASHBOARD] '{bookTitle}' este marcat ca disponibil.");
        }
    }
}
