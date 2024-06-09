using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Provider.Endpoint.Controllers;

[ApiController]
[Route("api/")]
public class MealPlannerControllerImplementation : ControllerBase
{
    private readonly IMealPlannerService _mealPlannerService;
    public MealPlannerControllerImplementation(IMealPlannerService mealPlannerService)
    {
        _mealPlannerService = mealPlannerService;
    }

    [HttpGet]
    [Route("meals")]
    public List<Meal> GetAllMeals()
    {
        return _mealPlannerService.GetAllMeals();
    }
    
    [HttpGet]
    [Route("meals/{id}")]
    public List<MealIngredients> GetMeal(int id)
    {
        return _mealPlannerService.GetMealIngredients(id);
    }

    [HttpPost]
    [Route("meals")]
    public List<IngredientAndMealIngredient> GetIngredientsList([FromBody] MealIdsRequest request)
    {
        return _mealPlannerService.GetIngredientsList(request.MealIds);
    }
    
    [HttpGet]
    [Route("ingredients")]
    public List<Ingredient> GetAllIngredients()
    {
        return _mealPlannerService.GetAllIngredients();
    }
}