namespace DigitalLibraryManagementSystem.Adapters
{
    // Clasa externa Stripe - API incompatibil cu sistemul nostru
    public class StripeService
    {
        public string ChargeCustomer(string customerId, int amountInCents)
        {
            Console.WriteLine($"[Stripe] Debitare {amountInCents} centi pentru customer {customerId}");
            return "stripe_txn_" + customerId;
        }
    }
}
