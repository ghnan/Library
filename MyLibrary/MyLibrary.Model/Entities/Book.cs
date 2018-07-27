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
        [DisplayName("编号")]
        public int BookID { get; set; }


        /// <summary>
        /// 书名
        /// </summary>
        [DisplayName("书名")]
        //[Required(AllowEmptyStrings = true,ErrorMessage ="尚有未填项，请完善")]
        public string Name { get; set; }


        /// <summary>
        /// 价格
        /// </summary>
        [DisplayName("价格")]
        public int Price { get; set; }


        /// <summary>
        /// 作者
        /// </summary>
        [DisplayName("作者")]
        public string Author { get; set; }


        /// <summary>
        /// 在馆数量
        /// </summary>
        [DisplayName("在馆数量")]
        public int Quantity { get; set; }
    }
}
