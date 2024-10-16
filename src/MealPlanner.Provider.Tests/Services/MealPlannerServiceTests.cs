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
    public void GetShoppingListShouldReturnEmptyListWhenNoIngredientsRequired()
    {
        this.Given(x => GivenAGetShoppingListRequest())
            .And(x => GivenRecipeIngredients(10, 10))
            .And(x => GivenUserIngredients(50, 50))
            .When(x => WhenGetShoppingListIsCalled())
            .Then(x => ThenItShouldReturnAnEmptyList())
            .BDDfy();
    }
    
    [Fact]
    public void GetShoppingListShouldReturnOnlyIngredientsRequiredAndRequiredAmounts()
    {
        this.Given(x => GivenAGetShoppingListRequest())
            .And(x => GivenRecipeIngredients(50, 50 ))
            .And(x => GivenUserIngredients(10, 100))
            .When(x => WhenGetShoppingListIsCalled())
            .Then(x => ThenItShouldReturnTheShoppingList())
            .BDDfy();
    }

    private void GivenAGetShoppingListRequest()
    {
        _request = new ShoppingListRequest
        {
            UserId = 1,
            RecipeIds = [1]
        };
    }
    
    private void GivenRecipeIngredients(int quantityA, int quantityB)
    {
        List<RecipeIngredientDTO> recipeIngredients =
        [
            new RecipeIngredientDTO
            {
                RecipeId = 1,
                IngredientId = 1,
                RecipeIngredientQuantity = quantityA
            },

            new RecipeIngredientDTO
            {
                RecipeId = 1,
                IngredientId = 2,
                RecipeIngredientQuantity = quantityB
            },
        ];

        _recipeIngredientRepository.GetRecipeIngredients(_request.RecipeIds).Returns(recipeIngredients);
    }
    private void GivenUserIngredients(int quantityA, int quantityB)
    {
        List<UserIngredient> userIngredients =
        [
            new UserIngredient
            {
                IngredientId = 1,
                Quantity = quantityA
            },
        
            new UserIngredient
            {
                IngredientId = 2,
                Quantity = quantityB
            }
        ];
        
        _userIngredientRepository.GetUserIngredients(_request.UserId).Returns(userIngredients);
    }
    private void WhenGetShoppingListIsCalled()
    {
        _result = _subject.GetShoppingList(_request);
    }

    private void ThenItShouldReturnTheShoppingList()
    {
        _result.ShouldNotBeEmpty();
        _result.Count.ShouldBe(1);
        _result[0].RecipeIngredientQuantity.ShouldBe(40);
    }
    
    private void ThenItShouldReturnAnEmptyList()
    {
        _result.ShouldBeEmpty();
    }


}
