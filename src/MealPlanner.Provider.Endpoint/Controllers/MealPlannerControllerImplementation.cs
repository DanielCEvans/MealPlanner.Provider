using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Models.DTOs;
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
    [Route("meals/{mealName}")]
    public List<MealIngredients> GetMeal(string mealName)
    {
        return _mealPlannerService.GetMealIngredients(mealName);
    }

    [HttpPost]
    [Route("meals")]
    public List<RequiredIngredient> GetIngredientsList([FromBody] MealIdsRequest request)
    {
        return _mealPlannerService.GetIngredientsList(request.MealNames);
    }
    
    [HttpGet]
    [Route("ingredients")]
    public List<Ingredient> GetAllIngredients()
    {
        return _mealPlannerService.GetAllIngredients();
    }

    [HttpPost]
    [Route("ingredients")]
    public string AddIngredient([FromBody] AddIngredientRequest request)
    {
        return "Ingredient added :)";
    }
}