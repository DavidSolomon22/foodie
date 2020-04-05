using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<DailyDiet> DailyDiets {get; set;} 
        public DbSet<DailyMeal> DailyMeals {get; set;} 
        public DbSet<Diet> Diets {get; set;} 
        public DbSet<Ingredient> Ingredients {get; set;} 
        public DbSet<LikedRecipe> LikedRecipes {get; set;} 
        public DbSet<Meal> Meals {get; set;} 
        public DbSet<Rate> Rates {get; set;} 
        public DbSet<Recipe> Recipes {get; set;}
        public DbSet<Step> Steps {get; set;}
        public DbSet<UserDiet> UserDiets {get; set;}

    }
}