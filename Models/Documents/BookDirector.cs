namespace DigitalLibraryManagementSystem.Models.Documents
{
    public class BookDirector
    {
        public Book BuildProgrammingBook(BookBuilder builder)
        {
            return builder
                .SetTitle("Clean Code")
                .SetAuthor("Robert C. Martin")
                .SetGenre("Programming")
                .SetPages(464)
                .SetISBN("978-0132350884")
                .Build();
        }

        public Book BuildDatabaseBook(BookBuilder builder)
        {
            return builder
                .SetTitle("Database Systems")
                .SetAuthor("C. J. Date")
                .SetGenre("Databases")
                .SetPages(350)
                .SetISBN("978-0321197849")
                .Build();
        }
    }
}