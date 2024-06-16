using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Models;

[Table("ingredient")]
[PrimaryKey(nameof(IngredientName), nameof(MeasurementUnit))]
public class Ingredient
{
    [Key]
    [Column("ingredient_name")]
    public string IngredientName { get; set; }
    
    [Key]
    [Column("measurement_unit")]
    public string MeasurementUnit { get; set; }

    [Column("ingredient_amount")] 
    public int IngredientAmount { get; set; }

    [Column("ingredient_category")]
    public string IngredientCategory { get; set; }

    public ICollection<MealIngredients> MealIngredients { get; set; }
}