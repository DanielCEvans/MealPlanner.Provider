using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("RecipeIngredients")]
public class RecipeIngredient
{
    [Key]
    public int Id { get; set; }

    public int RecipeId { get; set; }
    public int IngredientId { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Quantity { get; set; }

    [ForeignKey("RecipeId")]
    public Recipe Recipe { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient Ingredient { get; set; }
    
}