using MyLibrary.Student.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Student.Extensions
{
    /// <summary>
    /// LoginType 扩展
    /// </summary>
    public static class LoginTypeExtensions
    {
        /// <summary>
        /// 得到LoginType的Int32值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetValue(this LoginType type)
        {
            return (int)type;
        }

        /// <summary>
        /// 获取到描述信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDesc(this LoginType type)
        {
            if(type == LoginType.AdminLogin)
            {
                return "管理员登陆";
            }

            return "";
        }
    }
}
