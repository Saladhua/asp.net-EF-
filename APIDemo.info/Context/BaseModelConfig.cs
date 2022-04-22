using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using APIModel;



namespace APIDemo.info.Context
{
    public class BaseModelConfig
    {

        public static void SetBaseEntityConfig<T>(EntityTypeConfiguration<T> baseEntity)
           where T : BaseModel
        {
            baseEntity.HasKey(x => x.ID);
            baseEntity.Property(x => x.CreatedBy).HasMaxLength(50).IsRequired();
            baseEntity.Property(x => x.CreateTime).HasColumnType("datetime");
            baseEntity.Property(x => x.ModifyBy).HasMaxLength(50);
            baseEntity.Property(x => x.ModifyTime).HasColumnType("datetime");
            baseEntity.Property(x => x.IsDelete);
        }
    }
}
