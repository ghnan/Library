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
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AdminID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string AdminUserName { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        public string AdminPwd { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public int Phone { get; set; }
    }
}
