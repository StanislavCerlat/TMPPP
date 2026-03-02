using DigitalLibraryManagementSystem.Models.Users;
using DigitalLibraryManagementSystem.Models.Documents;

namespace DigitalLibraryManagementSystem.AbstractFactories
{
    public interface ILibraryFactory
    {
        User CreateUser(string id, string name, string email);
        Document CreateDocument(string title, string author);
    }
}