using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("管理员ID")]
        public int AdminID { get; set; }

        [DisplayName("用户名")]
        public string AdminUserName { get; set; }

        [DisplayName("密码")]
        public string AdminPwd { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("电话")]
        public int Phone { get; set; }
    }
}
