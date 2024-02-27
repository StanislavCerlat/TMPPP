using DigitalLibraryManagementSystem.Models.Documents;
using DigitalLibraryManagementSystem.Models.Users;

namespace DigitalLibraryManagementSystem.Models.Loans
{
    public class Loan
    {
        public User User { get; }
        public Document Document { get; }

        public Loan(User user, Document document)
        {
            User = user;
            Document = document;
        }

        public void PrintLoanInfo()
        {
            Console.WriteLine($"{User.Name} borrowed {Document.Title}");
        }
    }
}