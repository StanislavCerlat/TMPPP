namespace DigitalLibraryManagementSystem.Services
{
    public sealed class LibrarySystem
    {
        private static readonly Lazy<LibrarySystem> _instance =
            new Lazy<LibrarySystem>(() => new LibrarySystem());

        private LibrarySystem()
        {
        }

        public static LibrarySystem Instance => _instance.Value;

        public void PrintSystemInfo()
        {
            Console.WriteLine("Digital Library System Active");
        }
    }
}