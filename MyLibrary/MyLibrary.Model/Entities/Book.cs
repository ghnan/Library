using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.Entities
{
    public class Book
    {
        [Key]
        [DisplayName("编号")]
        public int BookID { get; set; }
        [DisplayName("书名")]
        public string Name { get; set; }

        [DisplayName("价格")]
        public int Price { get; set; }

        [DisplayName("作者")]
        public string Author { get; set; }

        [DisplayName("在馆数量")]
        public int Quantity { get; set; }

        public List<Book> Books { get; set; }
    }
}
