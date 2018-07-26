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

        public string StudentName { get; set; }

        public string BookName { get; set; }

        public DateTime date { get; set; } 
    }
}
