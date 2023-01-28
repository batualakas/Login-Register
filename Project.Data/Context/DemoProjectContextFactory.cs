using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Context
{
    public class DemoProjectContextFactory : IDesignTimeDbContextFactory<DemoProjectContext>
    {
      public DemoProjectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DemoProjectContext>();
            optionsBuilder.UseSqlServer("server =DESKTOP-3OF7PCV; database= DemoProjeDenemeDb; uid= batu; pwd=123;Encrypt=False;");
            return new DemoProjectContext(optionsBuilder.Options);
        }
    }
}
