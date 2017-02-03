using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UoW.Models;

namespace UoW.App_Start
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base(nameOrConnectionString: "MyDbContext")
        {
            
        }

        public DbSet<User> Clientes { get; set; }
    }
}