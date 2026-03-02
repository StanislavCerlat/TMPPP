using DigitalLibraryManagementSystem.Models.Users;
using DigitalLibraryManagementSystem.Models.Documents;

namespace DigitalLibraryManagementSystem.AbstractFactories
{
    public class DigitalLibraryFactory : ILibraryFactory
    {
        public User CreateUser(string id, string name, string email)
        {
            return new Student(id, name, email);
        }

        public Document CreateDocument(string title, string author)
        {
            return new Book(title, author);
        }
    }
}