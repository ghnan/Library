using MyLibrary.Borrowing.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Borrowing.Services
{
    public static class BorrowingService
    {
        static BorrowingDbContext Bodb = new BorrowingDbContext();

        /// <summary>
        /// 通过书籍名称借阅书籍
        /// </summary>
        /// <param name="BookName"></param>
        /// <param name="StudentName"></param>
        public static bool DoBorrowingByName(string BookName,string StudentName)
        {
            Model.Entities.Book book = new Model.Entities.Book();
            book.Name = BookName;
            bool flag = Book.Services.BookService.JudgeBook(BookName);
            List<Model.Entities.Borrowing> borrowingqueries = Bodb.borrowings.Where(s => s.StudentName == StudentName).ToList();
            Model.Entities.Borrowing borrowingquery = borrowingqueries.FirstOrDefault();
            if (flag)
            {
                Book.Services.BookService.BorrowingUpdateBookQuantity(book);

                Model.Entities.Borrowing borrowing = new Model.Entities.Borrowing();
                borrowing.Date = DateTime.Now;
                borrowing.Date_Return = null;
                borrowing.BookName = BookName;
                borrowing.StudentName = StudentName;
                borrowing.State = 1;
                Bodb.borrowings.Add(borrowing);
                Bodb.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 归还书籍时，判断该用户是否借了这本书
        /// </summary>
        /// <param name="BookName"></param>
        /// <param name="StudentName"></param>
        /// <returns></returns>
        public static bool JudgeReturn(string BookName,string StudentName)
        {
            bool flag = false;
            List<Model.Entities.Borrowing> borrowingqueries = Bodb.borrowings.Where(s => s.StudentName == StudentName).ToList();
            Model.Entities.Borrowing borrowingquery = borrowingqueries.FirstOrDefault();
            if (borrowingquery == null)
            {
                flag = false;
            }
            else
            {
                List<Model.Entities.Borrowing> borrowingqueries2 = Bodb.borrowings.Where(s => s.BookName == BookName).ToList();
                Model.Entities.Borrowing borrowingquery2 = borrowingqueries2.Last();
                if (borrowingquery2 != null)
                {
                    if (borrowingquery2.State == 1)
                    {
                        flag = true;
                    }
                }
                else flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 通过书名归还书籍
        /// </summary>
        /// <param name="BookName"></param>
        /// <param name="StudentName"></param>
        /// <returns></returns>
        public static bool DoReturnByName(string BookName,string StudentName)
        {
            Model.Entities.Borrowing borrowing = new Model.Entities.Borrowing();
            borrowing.BookName = BookName;
            borrowing.StudentName = StudentName;
            bool flag = JudgeReturn(BookName, StudentName);
            if (flag)
            {
                Model.Entities.Book book = new Model.Entities.Book();
                book.Name = BookName;
                Book.Services.BookService.ReturnUpdateBookQuantity(book);

                borrowing.Date_Return = DateTime.Now;
                borrowing.Date = null;
                borrowing.State = 2;
                Bodb.borrowings.Add(borrowing);
                Bodb.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Model.Entities.Borrowing> GetBorrowings()
        {
            return Bodb.borrowings.ToList();
        }
    }
}
