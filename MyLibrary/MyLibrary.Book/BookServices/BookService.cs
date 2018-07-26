using MyLibrary.Book.DbContext;
using System.Collections.Generic;
using System.Linq;


namespace MyLibrary.Book.BookServices
{
    public static  class BookService
    {
        /// <summary>
        /// 定义图书数据库上下文
        /// </summary>
        static BookDbContext Bdb = new BookDbContext();

        /// <summary>
        /// 添加书籍
        /// </summary>
        /// <param name="book"></param>
        public static void AddBook(Model.Entities.Book book)
        {
            Bdb.Books.Add(book);
            Bdb.SaveChanges();
        }

        public static List<Model.Entities.Book> GetBooks()
        {
            return Bdb.Books.ToList();
        }
        /// <summary>
        /// 未知
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public static List<Model.Entities.Book> SelectBooksByName(string Name)
        {
            List<Model.Entities.Book> bookList = Bdb.Books.Where(book => book.Name == Name).ToList();
            return bookList;
        }
    }
}
