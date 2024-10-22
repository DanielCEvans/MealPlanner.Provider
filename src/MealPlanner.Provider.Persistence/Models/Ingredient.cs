using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("Ingredients")]
public class Ingredient
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(255)]
    public string Name { get; init; }

    [Required]
    public DatabaseMeasurementUnit Unit { get; init; }

    public int CategoryId { get; init; }

    [ForeignKey("CategoryId")]
    public IngredientCategory Category { get; init; }
    
    public int? GramsPerCup { get; init; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; init; }
    public ICollection<UserIngredient> UserIngredients { get; init; }
    public ICollection<ShoppingListItem> ShoppingListItems { get; init; }
    
}

public enum DatabaseMeasurementUnit
{
    gm,
    ml,
    singular
}
