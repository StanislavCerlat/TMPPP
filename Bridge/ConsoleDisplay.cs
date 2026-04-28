using System;

namespace DigitalLibraryManagementSystem.Bridge
{
    public class ConsoleDisplay : IDisplay
    {
        public void Render(string content)
        {
            Console.WriteLine(content);
        }
    }
}
