using System;
using DigitalLibraryManagementSystem.Models.Users;
using DigitalLibraryManagementSystem.Models.Documents;
using DigitalLibraryManagementSystem.Models.Loans;
using DigitalLibraryManagementSystem.Services;
using DigitalLibraryManagementSystem.Factories;
using DigitalLibraryManagementSystem.AbstractFactories;

namespace DigitalLibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== SINGLETON TEST =====");
            var system1 = LibrarySystem.Instance;
            var system2 = LibrarySystem.Instance;

            Console.WriteLine($"Same instance: {ReferenceEquals(system1, system2)}");
            system1.PrintSystemInfo();


            Console.WriteLine("\n===== FACTORY METHOD TEST =====");
            UserFactory factory = new StudentFactory();
            User user = factory.CreateUser("1", "Ion", "ion@utm.md");

            Console.WriteLine($"User created: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Max loan days: {user.GetMaxLoanDays()}");


            Console.WriteLine("\n===== ABSTRACT FACTORY TEST =====");
            ILibraryFactory libraryFactory = new DigitalLibraryFactory();

            User afUser = libraryFactory.CreateUser("2", "Maria", "maria@utm.md");
            Document afDocument = libraryFactory.CreateDocument("Design Patterns", "Gamma");

            Console.WriteLine($"User created: {afUser.Name}");
            Console.WriteLine($"Email: {afUser.Email}");
            Console.WriteLine($"Max loan days: {afUser.GetMaxLoanDays()}");
            Console.WriteLine($"Document type: {afDocument.GetDocumentType()}");


            Console.WriteLine("\n===== LAB 1 TEST (Loan) =====");
            Loan loan = new Loan(afUser, afDocument);
            loan.PrintLoanInfo();
        }
    }
}