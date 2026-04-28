using System.Collections.Generic;

namespace DigitalLibraryManagementSystem.Strategy
{
    public interface ISortStrategy
    {
        List<string> Sort(List<string> books);
        string GetName();
    }
}
