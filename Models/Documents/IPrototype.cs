namespace DigitalLibraryManagementSystem.Models.Documents
{
    public interface IPrototype<T>
    {
        T Clone();
    }
}