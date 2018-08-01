using System.Collections.Generic;
using System.Linq;
using MyLibrary.Admin.DbContext;

namespace MyLibrary.Admin.Services
{
    public static class AdminService
    {
        /// <summary>
        /// 定义管理员数据上下文
        /// </summary>
        static AdminDbContext Adb = new AdminDbContext();

        /// <summary>
        /// 登录类型枚举
        /// </summary>
        public enum LoginType
        {
            /// <summary>
            /// 用户名为空
            /// </summary>
            UserNameIsNull = 1,
            /// <summary>
            /// 登录成功
            /// </summary>
            LoginSuccess = 2,
            /// <summary>
            /// 密码错误
            /// </summary>
            UserPwdIsFalse = 3,
            /// <summary>
            /// 用户名错误
            /// </summary>
            UserNameIsFalse = 4
        }

        /// <summary>
        /// 获得管理员信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.Entities.Admin> GetAdmin()
        {
            return Adb.Admins.ToList();
        }

        /// <summary>
        /// 注册管理员账户
        /// </summary>
        /// <param name="admin"></param>
        public static void Register(MyLibrary.Model.Entities.Admin admin)
        {
            Adb.Admins.Add(admin);
            Adb.SaveChanges();
        }

        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int DoLogin(string Name,string pwd)
        {
                if (Name == null)
                {
                    return (int)LoginType.UserNameIsNull;
                }
                else
                {
                    if (Adb.Admins.Any(s => s.AdminUserName == Name))
                    {
                        if (Adb.Admins.Single(s => s.AdminUserName == Name).AdminPwd == pwd)
                        {
                            return (int)LoginType.LoginSuccess;
                        }
                        else return (int)LoginType.UserNameIsFalse;
                    }
                    else return (int)LoginType.UserPwdIsFalse;
                }
        }
    }
}
