using System.Data.Entity;

namespace MyLibrary.Student.DbContext
{
    public class StudentDbContext : System.Data.Entity.DbContext
    {
        public StudentDbContext() : base("LibraryDataConn")
        {

        }
        public DbSet<MyLibrary.Model.Entities.Student> Students { get; set; }
    }
}