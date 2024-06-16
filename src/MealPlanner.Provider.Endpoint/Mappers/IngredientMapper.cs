using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public class IngredientMapper : IIngredientMapper
{
    public Ingredient ToPersistence(AddIngredientRequest ingredientRequest)
    {
        return new Ingredient()
        {
            IngredientName = ingredientRequest.IngredientName,
            MeasurementUnit = ingredientRequest.MeasurementUnit,
            IngredientAmount = ingredientRequest.IngredientAmount,
            IngredientCategory = ingredientRequest.IngredientCategory
        };
    }
}