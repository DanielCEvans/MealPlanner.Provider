using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("Ingredients")]
public class Ingredient
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Unit { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public IngredientCategory Category { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    public ICollection<UserIngredient> UserIngredients { get; set; }
    public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
}