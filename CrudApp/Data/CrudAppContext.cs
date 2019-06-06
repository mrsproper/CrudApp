using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTypeScript.Models;

namespace CrudApp.Models
{
    public class CrudAppContext : DbContext
    {
        public CrudAppContext (DbContextOptions<CrudAppContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCoreTypeScript.Models.Apple> Apple { get; set; }
    }
}
