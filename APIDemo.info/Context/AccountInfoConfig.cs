using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using APIModel;



namespace APIDemo.info.Context
{

    /// <summary>
    /// EntityTypeConfiguration 配置账户信息映射关系
    /// </summary>
    public class AccountInfoConfig : EntityTypeConfiguration<AccountInfo>
    {
        public AccountInfoConfig()
        {
            BaseModelConfig.SetBaseEntityConfig(this);
            Property(x => x.LoginID).HasMaxLength(50);
            Property(x => x.PassWord).HasMaxLength(50);
            Property(x => x.UserTrueName).HasMaxLength(50);
            Property(x => x.MobileNumber).HasMaxLength(50);
            Property(x => x.DepartmentName).HasMaxLength(50);
            Property(x => x.RoleName).HasMaxLength(50);
        }
    }
}
