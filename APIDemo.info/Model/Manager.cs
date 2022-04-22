using APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.info.Model
{
    /// <summary>
    /// 教练信息表
    /// </summary>
    public class Manager : BaseModel

    {
        /// <summary>
        /// 用户的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        ///    
        /// </summary>
        public int Flag { get; set; }
    }
}
