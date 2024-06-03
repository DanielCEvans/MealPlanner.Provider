using MealPlanner.Provider.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Provider.Endpoint.Controllers;

[ApiController]
[Route("api/")]
public class MealPlannerControllerImplementation : ControllerBase
{
    private readonly MealPlannerContext _dbContext;
    
    public MealPlannerControllerImplementation(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public string HelloWorld()
    {
        return "hello world";
    }
}