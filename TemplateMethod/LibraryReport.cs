using System;

namespace DigitalLibraryManagementSystem.TemplateMethod
{
    public abstract class LibraryReport
    {
        public void GenerateReport()
        {
            PrintHeader();
            CollectData();
            FormatBody();
            PrintFooter();
        }

        protected virtual void PrintHeader()
        {
            Console.WriteLine("=== Raport Biblioteca ===");
            Console.WriteLine($"Data: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }

        protected abstract void CollectData();
        protected abstract void FormatBody();

        protected virtual void PrintFooter()
        {
            Console.WriteLine("=== Sfarsit raport ===");
        }
    }

    public class BorrowedBooksReport : LibraryReport
    {
        protected override void CollectData()
        {
            Console.WriteLine("[Collect] Colectez lista de carti imprumutate...");
        }

        protected override void FormatBody()
        {
            Console.WriteLine("[Body] Top carti imprumutate: Clean Code, Design Patterns, Pragmatic Programmer");
        }
    }

    public class UserStatisticsReport : LibraryReport
    {
        protected override void CollectData()
        {
            Console.WriteLine("[Collect] Colectez statistici utilizatori...");
        }

        protected override void FormatBody()
        {
            Console.WriteLine("[Body] Utilizatori activi: 128 | Profesori: 22 | Studenti: 106");
        }
    }

    public class InventoryReport : LibraryReport
    {
        protected override void CollectData()
        {
            Console.WriteLine("[Collect] Colectez date despre inventar...");
        }

        protected override void FormatBody()
        {
            Console.WriteLine("[Body] Total documente: 5420 | Disponibile: 4988 | Indisponibile: 432");
        }
    }
}
