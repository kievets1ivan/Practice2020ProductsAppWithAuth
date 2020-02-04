using AppWithAuth.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithAuth.DataLayer
{
    public class ProductContext : IdentityDbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {

        }

        public DbSet<ProductEntity> ProductSet { get;set; }
    }
}
