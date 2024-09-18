using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("ShoppingListItems")]
public class ShoppingListItem
{
    [Key]
    public int ShoppingListItemId { get; set; }

    public int ShoppingListId { get; set; }
    public int IngredientId { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal RequiredQuantity { get; set; }

    [ForeignKey("ShoppingListId")]
    public ShoppingList ShoppingList { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient Ingredient { get; set; }
}