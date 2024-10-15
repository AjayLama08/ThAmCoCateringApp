using System.ComponentModel.DataAnnotations;

namespace ThAmCoCateringApp.Data
{
    public class MenuFoodItem
    {
        public int MenuId { get; set; }
        public int FoodItemId { get; set; }

        public Menu Menu { get; set; }

        public FoodItem FoodItem { get; set; }
    }
}
