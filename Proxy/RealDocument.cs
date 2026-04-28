using System;

namespace DigitalLibraryManagementSystem.Proxy
{
    public class RealDocument : IDocumentAccess
    {
        public void OpenDocument(string role)
        {
            Console.WriteLine($"Document opened for {role}.");
        }
    }
}
