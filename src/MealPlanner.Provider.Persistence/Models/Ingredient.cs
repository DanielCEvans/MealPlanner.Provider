using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("ingredient")]
public class Ingredient
{
    [Key]
    [Column("ingredient_id")]
    public int IngredientId { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("ingredient_name")]
    public string IngredientName { get; set; }
    
    public ICollection<MealIngredients> MealIngredients { get; set; }
    
}