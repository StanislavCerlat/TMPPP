using System;

namespace DigitalLibraryManagementSystem.Proxy
{
    public class DocumentProxy : IDocumentAccess
    {
        private readonly RealDocument _realDocument = new();

        public void OpenDocument(string role)
        {
            if (string.Equals(role, "Professor", StringComparison.OrdinalIgnoreCase))
            {
                _realDocument.OpenDocument(role);
                return;
            }

            Console.WriteLine("Access denied: only Professor can open this document.");
        }
    }
}
