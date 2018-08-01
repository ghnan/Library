using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Student.Enums
{
    /// <summary>
    /// 登录类型枚举
    /// </summary>
    public enum LoginType
    {
        /// <summary>
        /// 切换到管理员登录
        /// </summary>
        AdminLogin = 0,
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
}
