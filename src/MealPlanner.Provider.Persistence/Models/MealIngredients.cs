using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Models;

[Table("meal_ingredients")]
[PrimaryKey(nameof(Meal), nameof(Ingredient))]
public class MealIngredients
{
    [Key]
    [Column("meal")]
    public string Meal;
    
    [Key]
    [Column("ingredient")]
    public string Ingredient;
    
    [Column("ingredient_amount")]
    public string IngredientAmount { get; set; }

}
