using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Models.DTOs;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public class MealMapper : IMealMapper
{
    public Meal AddMealRequestToMealPersistence(AddMealRequest addMealRequest)
    {
        return new Meal()
        {
            MealName = addMealRequest.MealName,
            MealType = addMealRequest.MealType
        };
    }

    public List<MealDTO> MealToMealDTO(List<Meal> meals)
    {
        List<MealDTO> mealDtos = new List<MealDTO>();
        foreach (var meal in meals)
        {
            mealDtos.Add(new MealDTO()
            {
                name = meal.MealName,
                type = meal.MealType
            });
        }
        return mealDtos;
    }
}