using MyLibrary.Student.DbContext;
using System.Collections.Generic;
using System.Linq;
using MyLibrary.Student.Extensions;
using MyLibrary.Student.Enums;

namespace MyLibrary.Student.Services
{
    public static class StudentService
    {
        static StudentDbContext Sdb = new StudentDbContext();

      

        /// <summary>
        /// 登录判断
        /// 返回值为1：用户名为空
        /// 返回值为2：登录成功
        /// 返回值为3：密码错误
        /// 返回值为4：用户不存在
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int DoLogin(string flag,Model.Entities.Student student)
        {
            string Name = student.Name;
            
            if (flag == "option1")
            {
                if (student.StudentUserName == null)
                {
                    return LoginType.UserNameIsNull.GetValue();
                }
                else
                {
                    if (Sdb.Students.Any(s => s.StudentUserName == student.StudentUserName))
                    {
                        if (Sdb.Students.Single(s => s.StudentUserName == student.StudentUserName).StudentPwd == student.StudentPwd)
                        {
                            return (int)LoginType.LoginSuccess;
                        }
                        else return (int)LoginType.UserPwdIsFalse;
                    }
                    else return (int)LoginType.UserNameIsFalse;
                }
            }
            else return (int)LoginType.AdminLogin;
        }

        /// <summary>
        /// 保存用户注册信息
        /// </summary>
        /// <param name="student"></param>
        public static void DoRegister(Model.Entities.Student student)
        {
            Sdb.Students.Add(student);
            Sdb.SaveChanges();
        }

        /// <summary>
        /// 获得学生信息
        /// </summary>
        public static List<Model.Entities.Student> GetSudentInfo()
        {
            return Sdb.Students.ToList();
        }
    }
}
