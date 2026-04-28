namespace DigitalLibraryManagementSystem.Adapters
{
    // Serviciul bibliotecii care proceseaza amenzi - foloseste IPaymentProcessor
    public class FinePaymentService
    {
        private readonly IPaymentProcessor _processor;

        public FinePaymentService(IPaymentProcessor processor)
        {
            _processor = processor;
        }

        public void PayFine(string userId, decimal fineAmount)
        {
            Console.WriteLine($"\nPlata amenda prin {_processor.GetProcessorName()}:");
            bool success = _processor.ProcessPayment(userId, fineAmount);
            Console.WriteLine(success
                ? $"  Amenda de {fineAmount} MDL platita cu succes!"
                : "  Plata a esuat.");
        }
    }
}
