using Microsoft.EntityFrameworkCore;

namespace CakeApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CakeApplication.Data;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.Elfie.Serialization;



public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CakeApplicationContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CakeApplicationContext>>()))
        {
            // Look for any movies.
            if (context.Cakes.Any())
            {
                return;   // DB has been seeded
            }
            context.Cakes.AddRange(
                new Cakes
                {
                    Title = "Crafting Delicious Delights",
                    OrderDate = DateTime.Parse("2024-3-05"),
                    Flavour = "chocolate" + "vanilla" + "strawberry",
                    Price = 299.99M
                },
                new Cakes
                {
                    Title = "Your Sweet Tooth's Havens",
                    OrderDate = DateTime.Parse("2024-3-08"),
                    Flavour = "Red Velvet with cream cheese frosting",
                    Price = 399.99M
                },
              new Cakes
              {
                  Title = "Creating Magic, One Slice at a Time",
                  OrderDate = DateTime.Parse("2024-3-18"),
                  Flavour = " Signature flavors or seasonal specialties",
                  Price = 550.00M
              },
                new Cakes
                {
                    Title = "Explore the World of Sweet Creations",
                    OrderDate = DateTime.Parse("2024-3-11"),
                    Flavour = "customizations requested like fondand cakes",
                    Price = 799.99M
                }
            );
            context.SaveChanges();
        }
    }
}


