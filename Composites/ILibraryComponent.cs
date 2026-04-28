namespace DigitalLibraryManagementSystem.Composites
{
    // Componenta de baza pentru Composite - tratam uniform carti si colectii
    public interface ILibraryComponent
    {
        string Name { get; }
        void Display(int depth = 0);
        int GetTotalDocuments();
    }
}
