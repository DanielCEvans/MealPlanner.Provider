using MealPlanner.Provider.Endpoint.Models.DTOs;
using MealPlanner.Provider.Endpoint.Services;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;
using NSubstitute;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace MealPlanner.Provider.Tests.Services;

public class MealPlannerServiceTests
{
    private readonly MealPlannerService _subject;

    private readonly IMealRepository _mealRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMealIngredientRepository _mealIngredientRepository;

    private List<RequiredIngredient> _result;
    private List<int> MealIds;

    public MealPlannerServiceTests()
    {
        _mealRepository = Substitute.For<IMealRepository>();
        _ingredientRepository = Substitute.For<IIngredientRepository>();
        _mealIngredientRepository = Substitute.For<IMealIngredientRepository>();

        _subject = new MealPlannerService(
            _mealRepository,
            _ingredientRepository,
            _mealIngredientRepository);
    }

    [Fact]
    public void ItShouldReturnAnEmptyListOfIngredients()
    {
        this.Given(x => GivenAListOfMealIds())
            .And(x => GivenAllMealIngredientsAreLessThanKitchenIngredients())
            .When(x => WhenGetIngredientsListIsCalled())
            .Then(x => ThenItShouldReturnAnEmptyList())
            .BDDfy();
    }
    
    [Fact]
    public void ItShouldReturnOnlyTheIngredientsThatAreRequried()
    {
        this.Given(x => GivenAListOfMealIds())
            .And(x => GivenSomeMealIngredientsAreGreaterThanKitchenIngredients())
            .When(x => WhenGetIngredientsListIsCalled())
            .Then(x => ThenItShouldReturnTheIngredientsList())
            .BDDfy();
    }

    private void GivenAListOfMealIds()
    {
        MealIds = [1, 2, 3];
    }
    
    private void GivenSomeMealIngredientsAreGreaterThanKitchenIngredients()
    {
        List<IngredientAndMealIngredient> ingredients =
        [
            new()
            {
                IngredientName = "some ingredient",
                MealIngredientAmount = 100,
                KitchenIngredientAmount = 50,
            },

            new()
            {
                IngredientName = "another ingredient",
                MealIngredientAmount = 20,
                KitchenIngredientAmount = 50,
            },

            new()
            {
                IngredientName = "some ingredient",
                MealIngredientAmount = 20,
                KitchenIngredientAmount = 50,
            }
        ];

        _mealIngredientRepository.GetMealIngredients(MealIds).Returns(ingredients);
    }
    
    private void GivenAllMealIngredientsAreLessThanKitchenIngredients()
    {
        List<IngredientAndMealIngredient> ingredients =
        [
            new()
            {
                IngredientName = "some ingredient",
                MealIngredientAmount = 10,
                KitchenIngredientAmount = 50
            },

            new()
            {
                IngredientName = "another ingredient",
                MealIngredientAmount = 20,
                KitchenIngredientAmount = 50
            },

            new()
            {
                IngredientName = "some ingredient",
                MealIngredientAmount = 20,
                KitchenIngredientAmount = 50
            }
        ];

        _mealIngredientRepository.GetMealIngredients(MealIds).Returns(ingredients);
    }
    private void WhenGetIngredientsListIsCalled()
    {
        _result = _subject.GetIngredientsList(MealIds);
    }

    private void ThenItShouldReturnTheIngredientsList()
    {
        _result.ShouldNotBeEmpty();
        _result.Count.ShouldBe(1);
        _result[0].RequiredIngredientAmount.ShouldBe(70);
    }
    
    private void ThenItShouldReturnAnEmptyList()
    {
        _result.ShouldBeEmpty();
    }


}
