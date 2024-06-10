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

    private List<IngredientAndMealIngredient> _result;
    public List<int> MealIds;

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

    private void GivenAListOfMealIds()
    {
        MealIds = new List<int>{1,2,3};
    }
    private void GivenAllMealIngredientsAreLessThanKitchenIngredients()
    {
        List<IngredientAndMealIngredient> ingredients =
        [
            new()
            {
                IngredientName = "some ingredient",
                MealIngredientAmount = 10,
                KitchenIngredientAmount = 50,
                MeasurementUnit = "some unit"
            },

            new()
            {
                IngredientName = "another ingredient",
                MealIngredientAmount = 20,
                KitchenIngredientAmount = 50,
                MeasurementUnit = "some unit"
            },

            new()
            {
                IngredientName = "some ingredient",
                MealIngredientAmount = 20,
                KitchenIngredientAmount = 50,
                MeasurementUnit = "some unit"
            }
        ];

        _mealIngredientRepository.GetMealIngredients(MealIds).Returns(ingredients);
    }
    private void WhenGetIngredientsListIsCalled()
    {
        _result = _subject.GetIngredientsList(MealIds);
    }

    private void ThenItShouldReturnAnEmptyList()
    {
        _result.ShouldBeEmpty();
    }


}