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