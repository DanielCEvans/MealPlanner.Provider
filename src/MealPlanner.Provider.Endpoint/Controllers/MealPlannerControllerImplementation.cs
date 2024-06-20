using System.Net;
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
    public List<RequiredIngredient> GetIngredientsList([FromBody] GetIngredientsListRequest request)
    {
        return _mealPlannerService.GetIngredientsList(request.MealNames);
    }

    [HttpPost]
    [Route("meals/add")]
    public HttpStatusCode AddMeal([FromBody] AddMealRequest request)
    {
        try
        {
            _mealPlannerService.AddMeal(request);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
        {
            // TODO: if the meal already exists, return bad request 
            return HttpStatusCode.Conflict;
        }
            
        // 2. Add all ingredients into the database in the request
        // this will insert only ingredients that are not already in the database
        // this will assume that there is none of this ingredient in the 'Inventory'
        _mealPlannerService.AddIngredients(request.MealIngredients); 
        
        // TODO: add request to the MealIngredients table
        return HttpStatusCode.Created;
    }
    
    [HttpGet]
    [Route("ingredients")]
    public List<Ingredient> GetAllIngredients()
    {
        return _mealPlannerService.GetAllIngredients();
    }

    [HttpPost]
    [Route("ingredients")]
    public HttpStatusCode AddIngredient([FromBody] AddIngredientRequest request)
    {
        _mealPlannerService.AddIngredient(request);
        return HttpStatusCode.Created;
    }
}