using APIDemo.info.Model;
using APIModel;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Reflection;

namespace APIDemo.info.Context
{
    public class APIDbContext:DbContext
    {
        public APIDbContext() : base("name=MyConnection")
        {
            Database.SetInitializer(new APIDbSeed());
            //Database.SetInitializer<APIDbContext>(null);//从不创建数据库
            //Database.SetInitializer<APIDbContext>(new CreateDatabaseIfNotExists<APIDbContext>());//数据库不存在时创建数据库
            //Database.SetInitializer<APIDbContext>(new DropCreateDatabaseAlways<APIDbContext>());//每次启动时创建数据库
            //Database.SetInitializer<APIDbContext>(new DropCreateDatabaseIfModelChanges<APIDbContext>());//模型更改时创建数据库
        }

        #region DBSet
        public virtual DbSet<AccountInfo> AccountInfo { get; set; }
        public virtual DbSet<Course>  Courses { get; set; }
        public virtual DbSet<Manager>  Managers { get; set; }
        public virtual DbSet<Member>  Members { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //modelBuilder.Configurations.Add(new AccountInfoConfig());//使用单个文件生成数据表
            //使用加载数据集的方式生成数据表
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;
                var files = Directory.GetFiles(path, "*DAL.dll");
                if (files.Length == 0)
                {
                    path = Path.Combine(path, "bin");

                    files = Directory.GetFiles(path, "*DAL.dll");
                }
                foreach (var file in files)
                {
                    modelBuilder.Configurations.AddFromAssembly(Assembly.LoadFile(file));
                }
            }
            catch
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;
                var files = Directory.GetFiles(path, "*DAL.dll");
                if (files.Length == 0)
                {
                    path = Path.Combine(path, "bin");

                    files = Directory.GetFiles(path, "*DAL.dll");
                }
                foreach (var file in files)
                {
                    modelBuilder.Configurations.AddFromAssembly(Assembly.LoadFile(file));
                }
            }
        }

    }
}
