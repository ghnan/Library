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
        /// 获得管理员信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.Entities.Admin> GetAdmin()
        {
            return Adb.Admins.ToList();
        }

        public static void Register(MyLibrary.Model.Entities.Admin admin)
        {
            Adb.Admins.Add(admin);
            Adb.SaveChanges();
        }
    }
}
