using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("ShoppingLists")]
public class ShoppingList
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required]
    public DateTime GeneratedDate { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
}