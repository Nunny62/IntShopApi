﻿namespace IntShopApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=IntShop; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        public DbSet<Product> Product { get; set; }
    }
}
