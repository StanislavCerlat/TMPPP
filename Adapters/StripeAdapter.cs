namespace DigitalLibraryManagementSystem.Adapters
{
    // Adapter care face StripeService compatibil cu IPaymentProcessor
    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeService _stripeService;

        public StripeAdapter(StripeService stripeService)
        {
            _stripeService = stripeService;
        }

        public bool ProcessPayment(string userId, decimal amount)
        {
            // Adaptam: decimal lei -> int centi
            int amountInCents = (int)(amount * 100);
            string txn = _stripeService.ChargeCustomer(userId, amountInCents);
            return !string.IsNullOrEmpty(txn);
        }

        public string GetProcessorName() => "Stripe";
    }
}
