namespace DigitalLibraryManagementSystem.Command
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
        void Undo();
    }
}
