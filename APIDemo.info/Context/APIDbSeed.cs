using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace APIDemo.info.Context
{
    public class APIDbSeed : DropCreateDatabaseIfModelChanges<APIDbContext>
    {
        protected override void Seed(APIDbContext context)
        {
            base.Seed(context);
        }
    }
}
