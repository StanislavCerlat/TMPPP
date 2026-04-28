namespace DigitalLibraryManagementSystem.Adapters
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(string userId, decimal amount);
        string GetProcessorName();
    }
}
