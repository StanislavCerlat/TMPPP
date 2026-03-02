namespace DigitalLibraryManagementSystem.Services
{
    public sealed class LibrarySystem
    {
        private static LibrarySystem _instance;

        private LibrarySystem()
        {
        }

        public static LibrarySystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LibrarySystem();
                }
                return _instance;
            }
        }

        public void PrintSystemInfo()
        {
            Console.WriteLine("Digital Library System Active");
        }
    }
}