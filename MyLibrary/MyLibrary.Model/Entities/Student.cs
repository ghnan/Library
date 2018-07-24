using System;
using System.Collections.Generic;
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
        public int StudentID { get; set; }
        public string StudentPwd { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
    }
}
