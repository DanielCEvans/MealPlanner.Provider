using MealPlanner.Provider.Endpoint.Models;
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
    
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserIngredientRepository _userIngredientRepository;
    private readonly IRecipeIngredientRepository _recipeIngredientRepository;
    private readonly IShoppingLists _shoppingListsRepository;
        
    private List<RecipeIngredientDTO> _result;
    private ShoppingListRequest _request;

    public MealPlannerServiceTests()
    {
        _ingredientRepository = Substitute.For<IIngredientRepository>();
        _recipeRepository = Substitute.For<IRecipeRepository>();
        _userIngredientRepository = Substitute.For<IUserIngredientRepository>();
        _recipeIngredientRepository = Substitute.For<IRecipeIngredientRepository>();
        _shoppingListsRepository = Substitute.For<IShoppingLists>();

        _subject = new MealPlannerService(
            _ingredientRepository,
            _recipeRepository,
            _userIngredientRepository,
            _recipeIngredientRepository,
            _shoppingListsRepository);
    }

    [Fact]
    public void GetShoppingListShouldReturnEmptyListWhenNoIngredientsRequried()
    {
        this.Given(x => GivenAGetShoppingListRequest())
            .And(x => GivenRecipeIngredients())
            .And(x => GivenUserIngredients())
            .When(x => WhenGetShoppingListIsCalled())
            .Then(x => ThenItShouldReturnAnEmptyList())
            .BDDfy();
    }
    
    // [Fact]
    // public void GetShoppingListShouldReturnOnlyIngredientsRequried()
    // {
    //     this.Given(x => GivenAGetShoppingListRequest())
    //         .And(x => GivenSomeMealIngredientsAreGreaterThanKitchenIngredients())
    //         .When(x => WhenGetShoppingListIsCalled())
    //         .Then(x => ThenItShouldReturnTheIngredientsList())
    //         .BDDfy();
    // }

    private void GivenAGetShoppingListRequest()
    {
        _request = new ShoppingListRequest
        {
            UserId = 1,
            RecipeIds = [1]
        };
    }
    
    // private void GivenSomeMealIngredientsAreGreaterThanKitchenIngredients()
    // {
    //     List<IngredientAndMealIngredient> ingredients =
    //     [
    //         new()
    //         {
    //             IngredientName = "some ingredient",
    //             MealIngredientAmount = 100,
    //             KitchenIngredientAmount = 50,
    //         },
    //
    //         new()
    //         {
    //             IngredientName = "another ingredient",
    //             MealIngredientAmount = 20,
    //             KitchenIngredientAmount = 50,
    //         },
    //
    //         new()
    //         {
    //             IngredientName = "some ingredient",
    //             MealIngredientAmount = 20,
    //             KitchenIngredientAmount = 50,
    //         }
    //     ];
    //
    //     _mealIngredientRepository.GetMealIngredients(MealNames).Returns(ingredients);
    // }
    
    private void GivenRecipeIngredients()
    {
        List<RecipeIngredientDTO> recipeIngredients =
        [
            new RecipeIngredientDTO
            {
                RecipeId = 1,
                IngredientId = 1,
                RecipeIngredientQuantity = 10
            },

            new RecipeIngredientDTO
            {
                RecipeId = 1,
                IngredientId = 2,
                RecipeIngredientQuantity = 20
            },
        ];

        _recipeIngredientRepository.GetRecipeIngredients(_request.RecipeIds).Returns(recipeIngredients);
    }
    private void GivenUserIngredients()
    {
        List<UserIngredient> userIngredients =
        [
            new UserIngredient
            {
                IngredientId = 1,
                Quantity = 50
            },
        
            new UserIngredient
            {
                IngredientId = 2,
                Quantity = 50
            }
        ];
        
        _userIngredientRepository.GetUserIngredients(_request.UserId).Returns(userIngredients);
    }
    private void WhenGetShoppingListIsCalled()
    {
        _result = _subject.GetShoppingList(_request);
    }

    // private void ThenItShouldReturnTheIngredientsList()
    // {
    //     _result.ShouldNotBeEmpty();
    //     _result.Count.ShouldBe(1);
    //     _result[0].RequiredIngredientAmount.ShouldBe(70);
    // }
    
    private void ThenItShouldReturnAnEmptyList()
    {
        _result.ShouldBeEmpty();
    }


}
