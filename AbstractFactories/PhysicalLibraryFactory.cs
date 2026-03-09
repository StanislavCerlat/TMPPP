using DigitalLibraryManagementSystem.Models.Users;
using DigitalLibraryManagementSystem.Models.Documents;

namespace DigitalLibraryManagementSystem.AbstractFactories
{
    public class PhysicalLibraryFactory : ILibraryFactory
    {
        public User CreateUser(string id, string name, string email)
        {
            return new Professor(id, name, email);
        }

        public Document CreateDocument(string title, string author)
        {
            return new Magazine(title, author);
        }
    }
}