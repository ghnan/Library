using System.Data.Entity;

namespace MyLibrary.Admin.Properties
{
    class AdminDBContext : System.Data.Entity.DbContext
    {
        public AdminDBContext() : base("LibraryDataConn")
        {
        }
        public DbSet<MyLibrary.Model.Entities.Admin> Admins { get; set; }
    }
}
