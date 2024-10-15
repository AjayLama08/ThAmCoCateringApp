using Microsoft.EntityFrameworkCore;

namespace ThAmCoCateringApp.Data
{
    public class CateringDbContext : DbContext
    {
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        public string DbPath { get; set; } = string.Empty;

        public CateringDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "catering.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data source = {DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Compound key
            builder.Entity<MenuFoodItem>().HasKey(mfi => new { mfi.MenuId, mfi.FoodItemId });

            builder.Entity<FoodItem>()
                .HasMany(mfi => mfi.MenuFoodItems)
                .WithOne(fi => fi.FoodItem)
                .HasForeignKey(fi => fi.FoodItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Menu>()
                .HasMany(mfi => mfi.MenuFoodItems)
                .WithOne(m => m.Menu)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Vegetarian" },
                new Menu { MenuId = 2, MenuName = "Non-Vegetarian" },
                new Menu { MenuId = 3, MenuName = "Vegan" }
            );

            builder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookingId = 1, ClientReferenceId = 101, NumberOfGuests = 10, MenuId = 1 },
                new FoodBooking { FoodBookingId = 2, ClientReferenceId = 201, NumberOfGuests = 20, MenuId = 2 },
                new FoodBooking { FoodBookingId = 3, ClientReferenceId = 301, NumberOfGuests = 30, MenuId = 3 }
            );

            builder.Entity<FoodItem>().HasData(
                new FoodItem { FoodItemId = 1, Description = "Chicken curry", UnitPrice = 10 },
                new FoodItem { FoodItemId = 2, Description = "Steamed rice", UnitPrice = 20 },
                new FoodItem { FoodItemId = 3, Description = "Boiled eggs", UnitPrice = 30 }
            );
            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 3 }
            );



        }
    }
}
