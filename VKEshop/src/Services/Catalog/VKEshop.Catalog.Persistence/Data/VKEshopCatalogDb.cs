using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Domain;

namespace VKEshop.Catalog.Persistence.Data
{
    public class VKEshopCatalogDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public VKEshopCatalogDb(DbContextOptions<VKEshopCatalogDb> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                   new Category { Id=1, Name="Elektronik"},
                   new Category { Id = 2, Name = "Kırtasiye" }

                );

            modelBuilder.Entity<Product>().HasData
                (
                   new Product { Id =1 , Name="Tablet", Description="Tablet Açıklama", CategoryId=1, ImageUrl="resim adresi", Price=5000, Rating=4.0 },
                   new Product { Id = 2, Name = "Yazı Tahtası", Description = "Tahta Açıklama", CategoryId = 2, ImageUrl = "resim adresi", Price = 500, Rating = 4.8 },
                   new Product { Id = 3, Name = "Akıllı tartı", Description = "Baskül Açıklama", CategoryId = 1, ImageUrl = "resim adresi", Price = 900, Rating = 4.0 }


                );


        }

    }
}
