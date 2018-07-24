using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.Entities
{
    /// <summary>
    /// 管理员个人信息
    /// </summary>
     public class Admin
    {
        public int AdminID { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPwd { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
    }
}
