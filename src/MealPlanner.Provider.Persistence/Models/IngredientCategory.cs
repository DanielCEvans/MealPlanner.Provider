using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("IngredientCategories")]
public class IngredientCategory
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string CategoryName { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; }
}