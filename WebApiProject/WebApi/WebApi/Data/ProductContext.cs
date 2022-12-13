﻿using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class ProductContext:DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options ): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new() {Id =1,Name="Elektornik"},
                new() {Id =2,Name="Yaşam"}
             

            });



            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().Property(x => x.ImagePath).HasMaxLength(500);
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new(){Id =1, Name="Bilgisayar",CreatedDate=DateTime.Now.AddDays(-3),Price=15000,Stock=300 ,ImagePath ="ab",CategoryId=1},
                  new(){Id =2, Name="MOUSE",CreatedDate=DateTime.Now.AddDays(-3),Price=2000,Stock=200,ImagePath ="ab",CategoryId=1},
                    new(){Id =3, Name="TELEFON",CreatedDate=DateTime.Now.AddDays(-3),Price=25000,Stock=3100,ImagePath ="ab" ,CategoryId=1}
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set; }
    }
}
