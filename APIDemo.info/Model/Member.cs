using APIModel;

namespace APIDemo.info.Model
{
    /// <summary>
    /// 会员信息表
    /// </summary>
    public class Member : BaseModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Flag { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 确定密码
        /// </summary>
        public string TurePassword { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }
    }
}
