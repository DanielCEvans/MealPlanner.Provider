using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public class IngredientMapper : IIngredientMapper
{
    public Ingredient ToPersistence(AddIngredientRequest ingredientRequest)
    {
        return new Ingredient()
        {
            IngredientName = ingredientRequest.name,
            MeasurementUnit = ingredientRequest.unit,
            IngredientAmount = ingredientRequest.amount,
            IngredientCategory = ingredientRequest.category
        };
    }

    public List<Ingredient> ToPersistence(List<MealIngredient> ingredientRequest)
    {
        List<Ingredient> mealIngredients = new List<Ingredient>();

        foreach (var mealIngredient in ingredientRequest)
        {
            mealIngredients.Add(new Ingredient()
            {
                IngredientName = mealIngredient.IngredientName,
                MeasurementUnit = mealIngredient.MeasurementUnit,
                IngredientCategory = mealIngredient.IngredientCategory
            });
        }

        return mealIngredients;
    }
}