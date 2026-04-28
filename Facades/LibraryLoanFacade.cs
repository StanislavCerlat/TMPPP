namespace DigitalLibraryManagementSystem.Facades
{
    // --- Subsisteme interne complexe ---
    public class AvailabilityChecker
    {
        public bool CheckAvailability(string documentTitle)
        {
            Console.WriteLine($"  [AvailabilityChecker] Verificare disponibilitate: \"{documentTitle}\"...");
            return true;
        }
    }

    public class ReservationSystem
    {
        public string CreateReservation(string userId, string documentTitle)
        {
            string reservationId = $"RES-{userId}-{DateTime.Now.Ticks % 10000}";
            Console.WriteLine($"  [ReservationSystem] Rezervare creata: {reservationId}");
            return reservationId;
        }
    }

    public class LoanProcessor
    {
        public bool ProcessLoan(string reservationId, int loanDays)
        {
            Console.WriteLine($"  [LoanProcessor] Imprumut procesat pentru rezervarea {reservationId} - {loanDays} zile");
            return true;
        }
    }

    public class NotificationService
    {
        public void SendConfirmation(string userId, string documentTitle, int loanDays)
        {
            Console.WriteLine($"  [NotificationService] Email trimis catre {userId}: " +
                              $"\"Ai imprumutat '{documentTitle}' pentru {loanDays} zile.\"");
        }
    }

    // --- FACADE - ascunde complexitatea subsistemelor ---
    public class LibraryLoanFacade
    {
        private readonly AvailabilityChecker _availabilityChecker;
        private readonly ReservationSystem _reservationSystem;
        private readonly LoanProcessor _loanProcessor;
        private readonly NotificationService _notificationService;

        public LibraryLoanFacade()
        {
            _availabilityChecker = new AvailabilityChecker();
            _reservationSystem = new ReservationSystem();
            _loanProcessor = new LoanProcessor();
            _notificationService = new NotificationService();
        }

        public bool BorrowDocument(string userId, string documentTitle, int loanDays)
        {
            Console.WriteLine($"\nFacade: Initiere imprumut pentru utilizatorul '{userId}'...");

            if (!_availabilityChecker.CheckAvailability(documentTitle))
            {
                Console.WriteLine("  Documentul nu este disponibil.");
                return false;
            }

            string reservationId = _reservationSystem.CreateReservation(userId, documentTitle);

            if (!_loanProcessor.ProcessLoan(reservationId, loanDays))
            {
                Console.WriteLine("  Procesarea imprumutului a esuat.");
                return false;
            }

            _notificationService.SendConfirmation(userId, documentTitle, loanDays);
            Console.WriteLine("Facade: Imprumut finalizat cu succes!");
            return true;
        }
    }
}
