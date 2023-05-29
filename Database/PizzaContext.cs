using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Database
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PizzaModel> Pizzas { get; set; }

        public DbSet<PizzaCategory> PizzaCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzaDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
