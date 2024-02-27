using DigitalLibraryManagementSystem.Models.Users;

namespace DigitalLibraryManagementSystem.Factories
{
    public abstract class UserFactory
    {
        public abstract User CreateUser(string id, string name, string email);
    }

    public class StudentFactory : UserFactory
    {
        public override User CreateUser(string id, string name, string email)
        {
            return new Student(id, name, email);
        }
    }

    public class ProfessorFactory : UserFactory
    {
        public override User CreateUser(string id, string name, string email)
        {
            return new Professor(id, name, email);
        }
    }
}