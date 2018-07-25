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
        [DisplayName("学生ID")]
        public int StudentID { get; set; }

        [DisplayName("用户名")]
        public string StudentUserName { get; set; }

        [DisplayName("密码")]
        public string StudentPwd { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("电话")]
        public int Phone { get; set; }
    }
}