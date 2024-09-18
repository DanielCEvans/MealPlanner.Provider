using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("UserIngredients")]
public class UserIngredient
{
    [Key]
    public int UserIngredientId { get; set; }

    public int UserId { get; set; }
    public int IngredientId { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Quantity { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient Ingredient { get; set; }
}