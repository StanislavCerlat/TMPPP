namespace DigitalLibraryManagementSystem.Models.Users
{
    public abstract class User
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }

        protected User(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public abstract int GetMaxLoanDays();
    }
}