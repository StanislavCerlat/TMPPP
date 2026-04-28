using DigitalLibraryManagementSystem.Models.Documents;

namespace DigitalLibraryManagementSystem.Decorator
{
    public class BasicDocument : IDocumentComponent
    {
        private readonly Document _document;

        public BasicDocument(Document document)
        {
            _document = document;
        }

        public string GetInfo() => $"{_document.GetDocumentType()}: {_document.Title} by {_document.Author}";
    }
}
