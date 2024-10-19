using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MealPlanner.Provider.Endpoint.Models;

public class AddIngredientRequest
{
    public string Name { get; init; }
    public string Unit { get; init; }
    
    public int CategoryId { get; init; }
    public int? GramsPerCup { get; init; } 
}

