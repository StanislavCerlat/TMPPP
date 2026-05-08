using System;

namespace DigitalLibraryManagementSystem.State
{
    public interface ILoanState
    {
        string Name { get; }
        void Next(LoanContext context);
        void Previous(LoanContext context);
    }

    public class LoanContext
    {
        private ILoanState _state;

        public string BookTitle { get; }

        public LoanContext(string bookTitle)
        {
            BookTitle = bookTitle;
            _state = new PendingState();
            Console.WriteLine($"Imprumut creat pentru '{BookTitle}' in starea {_state.Name}.");
        }

        public void SetState(ILoanState state)
        {
            _state = state;
            Console.WriteLine($"Stare schimbata -> {_state.Name}");
        }

        public void Next() => _state.Next(this);
        public void Previous() => _state.Previous(this);
        public string GetStatus() => _state.Name;
    }

    public class PendingState : ILoanState
    {
        public string Name => "Pending";

        public void Next(LoanContext context) => context.SetState(new ValidatingState());

        public void Previous(LoanContext context)
        {
            Console.WriteLine("Pending este starea initiala.");
        }
    }

    public class ValidatingState : ILoanState
    {
        public string Name => "Validare";

        public void Next(LoanContext context) => context.SetState(new IssuedState());

        public void Previous(LoanContext context) => context.SetState(new PendingState());
    }

    public class IssuedState : ILoanState
    {
        public string Name => "Emis";

        public void Next(LoanContext context) => context.SetState(new ClosedState());

        public void Previous(LoanContext context) => context.SetState(new ValidatingState());
    }

    public class ClosedState : ILoanState
    {
        public string Name => "Inchis";

        public void Next(LoanContext context)
        {
            Console.WriteLine("Imprumutul este deja inchis.");
        }

        public void Previous(LoanContext context) => context.SetState(new IssuedState());
    }
}
