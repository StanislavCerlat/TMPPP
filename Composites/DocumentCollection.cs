namespace DigitalLibraryManagementSystem.Composites
{
    // Composite - o colectie de documente (sectiune, serie, raft)
    public class DocumentCollection : ILibraryComponent
    {
        public string Name { get; }
        private readonly List<ILibraryComponent> _children = new();

        public DocumentCollection(string name)
        {
            Name = name;
        }

        public void Add(ILibraryComponent component) => _children.Add(component);
        public void Remove(ILibraryComponent component) => _children.Remove(component);

        public void Display(int depth = 0)
        {
            Console.WriteLine($"{new string(' ', depth * 2)}[Colectie] {Name} ({GetTotalDocuments()} documente)");
            foreach (var child in _children)
                child.Display(depth + 1);
        }

        public int GetTotalDocuments()
        {
            int total = 0;
            foreach (var child in _children)
                total += child.GetTotalDocuments();
            return total;
        }
    }
}
