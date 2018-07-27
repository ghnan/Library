using MyLibrary.Student.DbContext;
using System.Linq;

namespace MyLibrary.Student.Services
{
    public static class StudentService
    {
        static StudentDbContext Sdb = new StudentDbContext();
        /// <summary>
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
                if (student.StudentUserName == "")
                {
                    return 1;
                }
                else
                {
                    if (Sdb.Students.Any(s => s.StudentUserName == student.StudentUserName))
                    {
                        if (Sdb.Students.Single(s => s.StudentUserName == student.StudentUserName).StudentPwd == student.StudentPwd)
                        {
                            return 2;
                        }
                        else return 3;
                    }
                    else return 4;
                }
            }
            else return 0;
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
    }
}
