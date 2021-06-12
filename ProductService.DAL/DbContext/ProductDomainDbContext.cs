using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ProductService.DAL.Entities;

namespace ProductService.DAL.DbContext
{
    class ProductDomainDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        private string _connectionString;

        public ProductDomainDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            //  .HasMany(c => c.Products);

            modelBuilder.Entity<Product>().ToTable("Products")
                .Property(p => p.Supplier)
                .HasColumnName("SupplierId")
                .HasConversion(
                    v => v.Id,
                    v => new SupplierRef() { Id = v });

            modelBuilder.Entity<Order>().ToTable("Orders")
                .HasKey(p => p.OrderId);

            modelBuilder.Entity<Order>().ToTable("Orders")
                .Property(o => o.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<Order>().ToTable("Orders")
                .Property(o => o.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("date('now')");

            modelBuilder.Entity<Order>().ToTable("Orders")
                .Property(o => o.ModifiedOn)
                .ValueGeneratedOnUpdate()
                .HasComputedColumnSql("date('now')");

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category)
            //    .WithMany(c => c.Products);


            //modelBuilder.Entity<Product>()
            //    .Navigation(p => p.Category)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
