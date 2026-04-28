namespace DigitalLibraryManagementSystem.Decorator
{
    public abstract class DocumentDecorator : IDocumentComponent
    {
        protected readonly IDocumentComponent Wrapped;

        protected DocumentDecorator(IDocumentComponent wrapped)
        {
            Wrapped = wrapped;
        }

        public virtual string GetInfo() => Wrapped.GetInfo();
    }
}
