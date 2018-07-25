using System.Data.Entity;


namespace MyLibrary.Book.DbContext
{
    class BookDbContext : System.Data.Entity.DbContext
    {
        public BookDbContext() : base("LibraryDataConn")
            {
                
            }
        public DbSet<MyLibrary.Model.Entities.Book> Books { get; set; }
    }
}
