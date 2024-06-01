using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Provider.Persistence.Models;

[Table("meal")]
public class Meal
{
    [Key]
    [Column("meal_id")]
    public int MealId { get; set; }
    
    [Column("meal_name")]
    public string MealName { get; set; }
    
    [Column("meal_type")]
    public string MealType { get; set; }
}