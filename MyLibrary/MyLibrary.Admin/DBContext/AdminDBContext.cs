using System.Data.Entity;

namespace MyLibrary.Admin.DbContext
{
    class AdminDbContext : System.Data.Entity.DbContext
    {
        public AdminDbContext() : base("LibraryDataConn")
        {
        }
        public DbSet<MyLibrary.Model.Entities.Admin> Admins { get; set; }
    }
}
