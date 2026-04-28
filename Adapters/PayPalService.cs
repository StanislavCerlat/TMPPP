namespace DigitalLibraryManagementSystem.Adapters
{
    // Clasa externa PayPal - API incompatibil cu sistemul nostru
    public class PayPalService
    {
        public bool MakePayment(string email, double amount)
        {
            Console.WriteLine($"[PayPal] Payment {amount:F2} USD from {email}");
            return true;
        }
    }
}
