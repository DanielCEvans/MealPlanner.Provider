using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Models;

[Table("meal_ingredients")]
[PrimaryKey(nameof(MealName), nameof(IngredientName))]
public class MealIngredients
{
    [Key] 
    [Column("meal_name")] 
    public string MealName { get; set; }

    [Key] 
    [Column("ingredient_name")] 
    public string IngredientName { get; set; }
    
    [Required]
    [Column("meal_ingredient_amount")]
    public int MealIngredientAmount { get; set; }
    
    [Column("ingredient_id")]
    [ForeignKey("ingredient_id")]
    public int IngredientId { get; set; }

    public Meal Meal { get; set; }
    public Ingredient Ingredient { get; set; }
}
