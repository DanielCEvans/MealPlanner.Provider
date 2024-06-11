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

    [Required]
    [Column("measurement_unit")]
    public string MeasurementUnit { get; set; }

    [Column("ingredient_amount")] 
    public int IngredientAmount { get; set; }

    [Column("ingredient_category")]
    public string IngredientCategory { get; set; }

    public ICollection<MealIngredients> MealIngredients { get; set; }
}