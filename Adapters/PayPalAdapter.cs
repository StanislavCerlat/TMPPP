namespace DigitalLibraryManagementSystem.Adapters
{
    // Adapter care face PayPalService compatibil cu IPaymentProcessor
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalService _payPalService;

        public PayPalAdapter(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        public bool ProcessPayment(string userId, decimal amount)
        {
            // Adaptam: userId devine email, decimal devine double
            string email = $"{userId}@utm.md";
            double amountUsd = (double)amount;
            return _payPalService.MakePayment(email, amountUsd);
        }

        public string GetProcessorName() => "PayPal";
    }
}
