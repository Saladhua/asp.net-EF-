
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModel
{
    /// <summary>
    /// 登录账户信息
    /// </summary>
    public class AccountInfo : BaseModel
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginID { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserTrueName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string RoleName { get; set; }
    }
}