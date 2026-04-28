namespace DigitalLibraryManagementSystem.Composites
{
    // Frunza (Leaf) - un document individual (carte, revista etc.)
    public class DocumentLeaf : ILibraryComponent
    {
        public string Name { get; }
        private readonly string _type;
        private readonly string _author;

        public DocumentLeaf(string name, string author, string type)
        {
            Name = name;
            _author = author;
            _type = type;
        }

        public void Display(int depth = 0)
        {
            Console.WriteLine($"{new string(' ', depth * 2)}[{_type}] \"{Name}\" - {_author}");
        }

        public int GetTotalDocuments() => 1;
    }
}
