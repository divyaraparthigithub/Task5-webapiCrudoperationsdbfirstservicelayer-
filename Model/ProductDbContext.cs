//using Microsoft.EntityFrameworkCore;
using Task5_webapiCrudoperationsdbfirstservicelayer_.Model;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Task5_webapiCrudoperationsdbfirstservicelayer_.Model
{
    public class ProductDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Product> Product { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Logtable> Logtable { get; set; }
    }
}

