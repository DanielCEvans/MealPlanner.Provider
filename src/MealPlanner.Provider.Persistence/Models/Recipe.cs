using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("Recipes")]
public class Recipe
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
}