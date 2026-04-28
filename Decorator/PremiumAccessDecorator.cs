namespace DigitalLibraryManagementSystem.Decorator
{
    public class PremiumAccessDecorator : DocumentDecorator
    {
        public PremiumAccessDecorator(IDocumentComponent wrapped) : base(wrapped)
        {
        }

        public override string GetInfo() => $"{base.GetInfo()} | Premium access enabled";
    }
}
