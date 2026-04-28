namespace DigitalLibraryManagementSystem.Bridge
{
    public abstract class DocumentView
    {
        protected readonly IDisplay Display;

        protected DocumentView(IDisplay display)
        {
            Display = display;
        }

        public abstract void Show(string title);
    }
}
