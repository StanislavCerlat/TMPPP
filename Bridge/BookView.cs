namespace DigitalLibraryManagementSystem.Bridge
{
    public class BookView : DocumentView
    {
        public BookView(IDisplay display) : base(display)
        {
        }

        public override void Show(string title)
        {
            Display.Render($"Book view: {title}");
        }
    }
}
