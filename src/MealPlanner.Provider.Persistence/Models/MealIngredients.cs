using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Models;

[Table("meal_ingredients")]
[PrimaryKey(nameof(MealId), nameof(IngredientId))]
public class MealIngredients
{   
    [Column("meal_id")]
    public int MealId;
    
    [Column("ingredient_id")]
    public int IngredientId;
    
    [Required]
    [Column("ingredient_amount")]
    public string IngredientAmount { get; set; }
    
    [ForeignKey(nameof(MealId))]
    public Meal Meal { get; set; }
    
    [ForeignKey(nameof(IngredientId))]
    public Ingredient Ingredient { get; set; }
    
}
