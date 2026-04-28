using System;

namespace DigitalLibraryManagementSystem.Bridge
{
    public class FancyDisplay : IDisplay
    {
        public void Render(string content)
        {
            Console.WriteLine($"*** {content} ***");
        }
    }
}
