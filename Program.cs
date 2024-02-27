using DigitalLibraryManagementSystem.Models.Users;
using DigitalLibraryManagementSystem.Models.Documents;
using DigitalLibraryManagementSystem.Models.Loans;
using DigitalLibraryManagementSystem.Services;
using DigitalLibraryManagementSystem.Factories;

UserFactory factory = new StudentFactory();
User student = factory.CreateUser("2", "Ion", "ion@utm.md");

Console.WriteLine(student.GetMaxLoanDays());

var book = new BookBuilder()
    .SetTitle("Design Patterns")
    .SetAuthor("Gamma et al.")
    .Build();

Console.WriteLine(book.GetDocumentType());

namespace DigitalLibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var system1 = LibrarySystem.Instance;
var system2 = LibrarySystem.Instance;

Console.WriteLine(system1 == system2); // trebuie True
system1.PrintSystemInfo();
            User student = new Student("1", "Ana", "ana@utm.md");
            Document book = new Book("OOP in C#", "Ion Popescu");

            Loan loan = new Loan(student, book);
            loan.PrintLoanInfo();
        }
    }
}