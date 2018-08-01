using MyLibrary.Book.DbContext;
using System.Collections.Generic;
using System.Linq;


namespace MyLibrary.Book.Services
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

        /// <summary>
        /// 返回书籍信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.Entities.Book> GetBooks()
        {
            return Bdb.Books.ToList();
        }

        /// <summary>
        /// 返回查询书籍结果
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public static List<Model.Entities.Book> SelectBooksByName(string Name)
        {
            List<Model.Entities.Book> bookList = Bdb.Books.Where(book => book.Name == Name).ToList();
            return bookList;
        }

        /// <summary>
        /// 通过书籍名称借阅书籍以后减少数量
        /// </summary>
        /// <param name="book"></param>
        public static void BorrowingByNameUpdateBookQuantity(Model.Entities.Book book)
        {
            List<Model.Entities.Book> bookqueries = Bdb.Books.Where(s => s.Name == book.Name).ToList();
            Model.Entities.Book bookquery = bookqueries.FirstOrDefault();

            bookquery.Quantity = bookquery.Quantity - 1;
            Bdb.SaveChanges();
        }

        public static void BorrowingByIDUpdateBookQuantity(Model.Entities.Book book)
        {
            List<Model.Entities.Book> bookqueries = Bdb.Books.Where(s => s.BookID == book.BookID).ToList();
            Model.Entities.Book bookquery = bookqueries.FirstOrDefault();

            bookquery.Quantity = bookquery.Quantity - 1;
            Bdb.SaveChanges();
        }

        /// <summary>
        /// 归还书籍以后增加数量
        /// </summary>
        /// <param name="book"></param>
        public static void ReturnUpdateBookQuantity(Model.Entities.Book book)
        {
            List<Model.Entities.Book> bookqueries = Bdb.Books.Where(s => s.Name == book.Name).ToList();
            Model.Entities.Book bookquery = bookqueries.FirstOrDefault();

            bookquery.Quantity = bookquery.Quantity + 1;
            Bdb.SaveChanges();
        }
        /// <summary>
        /// 更新书籍信息,暂时没用到，先留着
        /// </summary>
        /// <param name="book"></param>
        public static void UpdateBook(Model.Entities.Book book)
        {
            List<Model.Entities.Book> bookqueries = Bdb.Books.Where(s => s.Name == book.Name).ToList();
            Model.Entities.Book bookquery = bookqueries.FirstOrDefault();
            if (bookquery == null)
            {
                
            }
            else
            {
                bookquery.Name = book.Name;
                bookquery.Author = book.Author;
                bookquery.Price = book.Price;
                bookquery.Quantity = book.Quantity;
                Bdb.SaveChanges();
            }
        }

        /// <summary>
        /// 通过书籍名称借阅书籍时，判断书籍是否存在 
        /// </summary>
        /// <param name="BookName"></param>
        /// <returns></returns>
        public static bool JudgeBookByName(string bookname)
        {
            bool flag = false;
            List<Model.Entities.Book> bookqueries = Bdb.Books.Where(s => s.Name == bookname).ToList();
            Model.Entities.Book bookquery = bookqueries.FirstOrDefault();
            if (bookqueries.Count == 0)
            {
                flag = false;
            }
            else
            {
                if (bookquery.Quantity > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        /// <summary>
        /// 通过书籍ID借阅书籍时，判断书籍是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool JudgeBookByID(int id)
        {
            bool flag = false;
            List<Model.Entities.Book> bookqueries = Bdb.Books.Where(s => s.BookID == id).ToList();
            Model.Entities.Book bookquery = bookqueries.FirstOrDefault();
            if (bookqueries.Count == 0)
            {
                flag = false;
            }
            else
            {
                if (bookquery.Quantity > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        /// <summary>
        /// 通过书籍名称删除书籍
        /// </summary>
        /// <param name="BookName"></param>
        public static void DeleteBookByName(string BookName)
        {
            List<Model.Entities.Book> bookqueries = Bdb.Books.Where(s => s.Name == BookName).ToList();
            Model.Entities.Book bookquery = bookqueries.FirstOrDefault();
            if (bookquery == null)
            {
            }
            else
            {
                Bdb.Books.Remove(bookquery);
                Bdb.SaveChanges();
            }
        }

        /// <summary>
        /// 返回书籍信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.Entities.Book> BookInfo()
        {
            return Bdb.Books.ToList();
        }
    }
}
