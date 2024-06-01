using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("ingredient")]
public class Ingredient
{
    [Key]
    [Column("ingredient_id")]
    public int IngredientId { get; set; }
    
    [Column("ingredient_name")]
    public string IngredientName { get; set; }
    
}