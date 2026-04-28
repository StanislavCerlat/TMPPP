using System;
using DigitalLibraryManagementSystem.Models.Users;
using DigitalLibraryManagementSystem.Models.Documents;
using DigitalLibraryManagementSystem.Models.Loans;
using DigitalLibraryManagementSystem.Services;
using DigitalLibraryManagementSystem.Factories;
using DigitalLibraryManagementSystem.AbstractFactories;
using DigitalLibraryManagementSystem.Adapters;
using DigitalLibraryManagementSystem.Composites;
using DigitalLibraryManagementSystem.Facades;
using DigitalLibraryManagementSystem.Flyweight;
using DigitalLibraryManagementSystem.Decorator;
using DigitalLibraryManagementSystem.Bridge;
using DigitalLibraryManagementSystem.Proxy;
 
namespace DigitalLibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // =============================================
            // LABORATORUL 1-3 (cod existent)
            // =============================================
 
            Console.WriteLine("===== SINGLETON TEST =====");
            var system1 = LibrarySystem.Instance;
            var system2 = LibrarySystem.Instance;
            Console.WriteLine($"Same instance: {ReferenceEquals(system1, system2)}");
            system1.PrintSystemInfo();
 
            Console.WriteLine("\n===== BUILDER TEST =====");
            BookBuilder builder = new BookBuilder();
            Book customBook = builder
                .SetTitle("Design Patterns")
                .SetAuthor("GoF")
                .SetGenre("Software Engineering")
                .SetPages(395)
                .SetISBN("978-0201633610")
                .Build();
            customBook.PrintBookInfo();
 
            Console.WriteLine("\n===== PROTOTYPE TEST =====");
            Book clonedBook = customBook.Clone();
            Console.WriteLine("Original book:"); customBook.PrintBookInfo();
            Console.WriteLine("\nCloned book:"); clonedBook.PrintBookInfo();
 
            Console.WriteLine("\n===== FACTORY METHOD TEST =====");
            UserFactory factory = new StudentFactory();
            User user = factory.CreateUser("1", "Ion", "ion@utm.md");
            Console.WriteLine($"User created: {user.Name}, Max loan days: {user.GetMaxLoanDays()}");
 
            Console.WriteLine("\n===== ABSTRACT FACTORY TEST =====");
            ILibraryFactory libraryFactory = new DigitalLibraryFactory();
            User afUser = libraryFactory.CreateUser("2", "Maria", "maria@utm.md");
            Document afDocument = libraryFactory.CreateDocument("Design Patterns", "Gamma");
            Console.WriteLine($"User: {afUser.Name}, Document type: {afDocument.GetDocumentType()}");
 
            Console.WriteLine("\n===== LOAN TEST =====");
            Loan loan = new Loan(afUser, afDocument);
            loan.PrintLoanInfo();
 
            // =============================================
            // LABORATORUL 4 - Paternuri Structurale
            // =============================================
 
            Console.WriteLine("\n\n========================================");
            Console.WriteLine("   LABORATORUL 4 - PATERNURI STRUCTURALE");
            Console.WriteLine("========================================");
 
            // --- ADAPTER ---
            Console.WriteLine("\n===== ADAPTER TEST =====");
            Console.WriteLine("Scenariu: Plata amenzilor prin gateway-uri externe\n");
 
            // Adapter pentru PayPal
            var payPalAdapter = new PayPalAdapter(new PayPalService());
            var fineService1 = new FinePaymentService(payPalAdapter);
            fineService1.PayFine("student_ion", 25.50m);
 
            // Adapter pentru Stripe - acelasi cod client, alt gateway
            var stripeAdapter = new StripeAdapter(new StripeService());
            var fineService2 = new FinePaymentService(stripeAdapter);
            fineService2.PayFine("student_maria", 10.00m);
 
            Console.WriteLine("\nConcluzii Adapter: Sistemul foloseste IPaymentProcessor uniform,");
            Console.WriteLine("indiferent de PayPal sau Stripe, fara a modifica codul existent.");
 
            // --- COMPOSITE ---
            Console.WriteLine("\n===== COMPOSITE TEST =====");
            Console.WriteLine("Scenariu: Organizarea ierarhica a colectiei bibliotecii\n");
 
            // Documente individuale (frunze)
            var book1 = new DocumentLeaf("Clean Code", "Robert C. Martin", "Carte");
            var book2 = new DocumentLeaf("Design Patterns", "GoF", "Carte");
            var book3 = new DocumentLeaf("The Pragmatic Programmer", "Hunt & Thomas", "Carte");
            var mag1  = new DocumentLeaf("IEEE Software Vol.41", "IEEE", "Revista");
            var mag2  = new DocumentLeaf("ACM Computing Surveys", "ACM", "Revista");
 
            // Colectii (noduri compuse)
            var programmingSection = new DocumentCollection("Sectiunea: Programare");
            programmingSection.Add(book1);
            programmingSection.Add(book2);
            programmingSection.Add(book3);
 
            var magazineSection = new DocumentCollection("Sectiunea: Reviste Tehnice");
            magazineSection.Add(mag1);
            magazineSection.Add(mag2);
 
            // Biblioteca = radacina arborelui
            var library = new DocumentCollection("Biblioteca Digitala UTM");
            library.Add(programmingSection);
            library.Add(magazineSection);
 
            // Afisam toata ierarhia - acelasi apel Display() pentru frunze si colectii
            library.Display();
            Console.WriteLine($"\nTotal documente in biblioteca: {library.GetTotalDocuments()}");
            Console.WriteLine($"Total documente in Sectiunea Programare: {programmingSection.GetTotalDocuments()}");
 
            Console.WriteLine("\nConcluzii Composite: Colectiile si documentele individuale");
            Console.WriteLine("sunt tratate uniform prin ILibraryComponent.");
 
            // --- FACADE ---
            Console.WriteLine("\n===== FACADE TEST =====");
            Console.WriteLine("Scenariu: Imprumut simplificat prin Facade\n");
 
            var loanFacade = new LibraryLoanFacade();
 
            // Un singur apel simplu - Facade coordoneaza 4 subsisteme intern
            loanFacade.BorrowDocument("student_ion", "Clean Code", 14);
            loanFacade.BorrowDocument("prof_andrei", "Design Patterns", 30);
 
            Console.WriteLine("\nConcluzii Facade: Clientul apeleaza o singura metoda BorrowDocument()");
            Console.WriteLine("in loc sa interactioneze cu AvailabilityChecker, ReservationSystem,");
            Console.WriteLine("LoanProcessor si NotificationService separat.");

            Console.WriteLine("\n===== FLYWEIGHT TEST =====");
var t1 = BookTypeFactory.GetBookType("Programming", "EN");
var t2 = BookTypeFactory.GetBookType("Programming", "EN");
Console.WriteLine($"Same instance: {t1 == t2}");

Console.WriteLine("\n===== DECORATOR TEST =====");
var basic = new BasicDocument(new Book("Clean Code", "Robert Martin"));
var premium = new PremiumAccessDecorator(basic);
Console.WriteLine(premium.GetInfo());

Console.WriteLine("\n===== BRIDGE TEST =====");
var view = new BookView(new FancyDisplay());
view.Show("Design Patterns");

Console.WriteLine("\n===== PROXY TEST =====");
IDocumentAccess proxy = new DocumentProxy();
proxy.OpenDocument("Student");
proxy.OpenDocument("Professor");
        }
    }
}