namespace DigitalLibraryManagementSystem.Models.Users
{
    public class Professor : User
    {
        public Professor(string id, string name, string email)
            : base(id, name, email)
        {
        }

        public override int GetMaxLoanDays()
        {
            return 30;
        }
    }
}