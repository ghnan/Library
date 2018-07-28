using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.Entities
{
    /// <summary>
    /// 学生个人信息
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public int StudentID { get; set; }


        /// <summary>
        /// 用户名
        /// </summary>
        public string StudentUserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string StudentPwd { get; set; }

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