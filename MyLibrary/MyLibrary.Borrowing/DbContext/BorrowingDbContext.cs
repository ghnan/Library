using System.Data.Entity;

namespace MyLibrary.Borrowing.DbContext
{
    class BorrowingDbContext : System.Data.Entity.DbContext
    {
        public BorrowingDbContext() : base("LibraryDataConn")
        {

        }
        public DbSet<MyLibrary.Model.Entities.Borrowing> borrowings { get; set; }
    }
}
