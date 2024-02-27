namespace DigitalLibraryManagementSystem.Models.Users
{
    public class Student : User
    {
        public Student(string id, string name, string email)
            : base(id, name, email)
        {
        }

        public override int GetMaxLoanDays()
        {
            return 14;
        }
    }
}