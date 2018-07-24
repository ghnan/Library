using System.Data.Entity;

namespace MyLibrary.Student.Properties
{
    public class StudentDBContext : System.Data.Entity.DbContext
    {
        public StudentDBContext() : base("LibraryDataConn")
        {

        }
        public DbSet<MyLibrary.Model.Entities.Student> Students { get; set; }
    }
}