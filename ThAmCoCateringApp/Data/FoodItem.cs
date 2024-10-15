using System.ComponentModel.DataAnnotations;

namespace ThAmCoCateringApp.Data
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }

        public List<MenuFoodItem> MenuFoodItems { get; set; }
    }
}
