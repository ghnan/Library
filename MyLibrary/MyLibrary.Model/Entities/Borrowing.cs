using System;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Model.Entities
{
    public class Borrowing
    {
        /// <summary>
        /// 借阅编号
        /// </summary>
        [Key]
        public int BorrowingID { get; set; }

        /// <summary>
        /// 借阅学生名字
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 借阅书籍名字
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 借阅书籍时间
        /// </summary>
        public DateTime? Date { get; set; } 

        /// <summary>
        /// 归还书籍时间
        /// </summary>
        public DateTime? Date_Return { get; set; }

        /// <summary>
        /// 借阅状态,State=0时代表没有借书,State=1时代表借书没还，State=2时代表借书还书了
        /// </summary>
        public int? State { get; set; }
    }
}
