using System;

namespace DigitalLibraryManagementSystem.ChainOfResponsibility
{
    public class LibraryRequest
    {
        public string Type { get; }
        public string Description { get; }
        public int Complexity { get; }

        public LibraryRequest(string type, string description, int complexity)
        {
            Type = type;
            Description = description;
            Complexity = complexity;
        }
    }

    public abstract class RequestHandler
    {
        private RequestHandler? _next;

        public RequestHandler SetNext(RequestHandler next)
        {
            _next = next;
            return next;
        }

        public void Handle(LibraryRequest request)
        {
            if (CanHandle(request))
            {
                Process(request);
                return;
            }

            if (_next != null)
            {
                Console.WriteLine($"[{GetType().Name}] Escaladez cererea mai departe...");
                _next.Handle(request);
                return;
            }

            Console.WriteLine("Nu exista handler disponibil pentru aceasta cerere.");
        }

        protected abstract bool CanHandle(LibraryRequest request);
        protected abstract void Process(LibraryRequest request);
    }

    public class AssistantHandler : RequestHandler
    {
        protected override bool CanHandle(LibraryRequest request) => request.Complexity <= 1;

        protected override void Process(LibraryRequest request)
        {
            Console.WriteLine($"[Assistant] Cererea '{request.Description}' a fost rezolvata la nivelul Asistentului.");
        }
    }

    public class ITSpecialistHandler : RequestHandler
    {
        protected override bool CanHandle(LibraryRequest request) => request.Complexity == 2;

        protected override void Process(LibraryRequest request)
        {
            Console.WriteLine($"[IT Specialist] Cererea '{request.Description}' a fost rezolvata tehnic.");
        }
    }

    public class ManagerHandler : RequestHandler
    {
        protected override bool CanHandle(LibraryRequest request) => request.Complexity >= 3;

        protected override void Process(LibraryRequest request)
        {
            Console.WriteLine($"[Manager] Cererea complexa '{request.Description}' a fost aprobata/rezolvata managerial.");
        }
    }
}
