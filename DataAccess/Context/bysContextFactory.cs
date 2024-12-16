using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class bysContextFactory : IDesignTimeDbContextFactory<bysContext>
    {
        public bysContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<bysContext>();
            optionsBuilder.UseSqlServer("server=HPZEMZEM\\SQLEXPRESS;database=BYSDB; integrated security=true;trustServerCertificate=true");

            return new bysContext(optionsBuilder.Options);
        }
    }
}
