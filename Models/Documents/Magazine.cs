namespace DigitalLibraryManagementSystem.Models.Documents
{
    public class Magazine : Document
    {
        public Magazine(string title, string author)
            : base(title, author)
        {
        }

        public override string GetDocumentType()
        {
            return "Magazine";
        }
    }
}