using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Model.Entities
{
    /// <summary>
    /// 书籍信息
    /// </summary>
    public class Book
    {
        /// <summary>
        /// 书籍编号
        /// </summary>
        [Key]
        public int BookID { get; set; }


        /// <summary>
        /// 书名
        /// </summary>
        //[Required(AllowEmptyStrings = true,ErrorMessage ="尚有未填项，请完善")]
        public string Name { get; set; }


        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }


        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }


        /// <summary>
        /// 在馆数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
