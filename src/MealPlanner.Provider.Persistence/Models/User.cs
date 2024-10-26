using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; }

    [Required]
    public byte[] Fido2Id { get; set; }

    public ICollection<UserIngredient> UserIngredients { get; set; }
    public ICollection<ShoppingList> ShoppingLists { get; set; }
    public ICollection<StoredCredential> StoredCredentials { get; set; }
}