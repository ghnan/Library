using MyLibrary.Book.DbContext;
using System.Collections.Generic;
using System.Linq;


namespace MyLibrary.Book.BookServices
{
    public static  class BookServices
    {
        static BookDbContext Bdb = new BookDbContext();
        public static void AddBook(int BookID, string BookName, int BookPrice, string BookAuthor, int BookQuantity)
        {

            Model.Entities.Book book = new Model.Entities.Book();
            book.BookID = BookID;
            book.Name = BookName;
            book.Price = BookPrice;
            book.Author = BookAuthor;
            book.Quantity = BookQuantity;
            Bdb.Books.Add(book);
            Bdb.SaveChanges();
        }
       
        public static List<Model.Entities.Book> GetBooksByAuthor(string author)
        {
            List<Model.Entities.Book> bookList = Bdb.Books.Where(c => c.Author == author).ToList();
             
            return bookList;
        }
    }
}
