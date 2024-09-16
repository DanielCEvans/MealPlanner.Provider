// using MealPlanner.Provider.Endpoint.Mappers;
// using MealPlanner.Provider.Endpoint.Models.DTOs;
// using MealPlanner.Provider.Endpoint.Services;
// using MealPlanner.Provider.Persistence.Models;
// using MealPlanner.Provider.Persistence.Repositories;
// using NSubstitute;
// using Shouldly;
// using TestStack.BDDfy;
// using Xunit;
//
// namespace MealPlanner.Provider.Tests.Services;
//
// public class MealPlannerServiceTests
// {
//     private readonly MealPlannerService _subject;
//
//     private readonly IMealRepository _mealRepository;
//     private readonly IIngredientRepository _ingredientRepository;
//     private readonly IMealIngredientRepository _mealIngredientRepository;
//     private readonly IIngredientMapper _ingredientMapper;
//     private readonly IMealMapper _mealMapper;
//     private readonly IMealIngredientMapper _mealIngredientMapper;
//
//     private List<RequiredIngredient> _result;
//     private List<string> MealNames;
//
//     public MealPlannerServiceTests()
//     {
//         _mealRepository = Substitute.For<IMealRepository>();
//         _ingredientRepository = Substitute.For<IIngredientRepository>();
//         _mealIngredientRepository = Substitute.For<IMealIngredientRepository>();
//         _ingredientMapper = Substitute.For<IIngredientMapper>();
//         _mealMapper = Substitute.For<IMealMapper>();
//         _mealIngredientMapper = Substitute.For<IMealIngredientMapper>();
//
//         _subject = new MealPlannerService(
//             _mealRepository,
//             _ingredientRepository,
//             _mealIngredientRepository,
//             _ingredientMapper,
//             _mealMapper,
//             _mealIngredientMapper);
//     }
//
//     [Fact]
//     public void ItShouldReturnAnEmptyListOfIngredients()
//     {
//         this.Given(x => GivenAListOfMealIds())
//             .And(x => GivenAllMealIngredientsAreLessThanKitchenIngredients())
//             .When(x => WhenGetIngredientsListIsCalled())
//             .Then(x => ThenItShouldReturnAnEmptyList())
//             .BDDfy();
//     }
//     
//     [Fact]
//     public void ItShouldReturnOnlyTheIngredientsThatAreRequried()
//     {
//         this.Given(x => GivenAListOfMealIds())
//             .And(x => GivenSomeMealIngredientsAreGreaterThanKitchenIngredients())
//             .When(x => WhenGetIngredientsListIsCalled())
//             .Then(x => ThenItShouldReturnTheIngredientsList())
//             .BDDfy();
//     }
//
//     private void GivenAListOfMealIds()
//     {
//         MealNames = ["meal one", "meal two", "meal three"];
//     }
//     
//     private void GivenSomeMealIngredientsAreGreaterThanKitchenIngredients()
//     {
//         List<IngredientAndMealIngredient> ingredients =
//         [
//             new()
//             {
//                 IngredientName = "some ingredient",
//                 MealIngredientAmount = 100,
//                 KitchenIngredientAmount = 50,
//             },
//
//             new()
//             {
//                 IngredientName = "another ingredient",
//                 MealIngredientAmount = 20,
//                 KitchenIngredientAmount = 50,
//             },
//
//             new()
//             {
//                 IngredientName = "some ingredient",
//                 MealIngredientAmount = 20,
//                 KitchenIngredientAmount = 50,
//             }
//         ];
//
//         _mealIngredientRepository.GetMealIngredients(MealNames).Returns(ingredients);
//     }
//     
//     private void GivenAllMealIngredientsAreLessThanKitchenIngredients()
//     {
//         List<IngredientAndMealIngredient> ingredients =
//         [
//             new()
//             {
//                 IngredientName = "some ingredient",
//                 MealIngredientAmount = 10,
//                 KitchenIngredientAmount = 50
//             },
//
//             new()
//             {
//                 IngredientName = "another ingredient",
//                 MealIngredientAmount = 20,
//                 KitchenIngredientAmount = 50
//             },
//
//             new()
//             {
//                 IngredientName = "some ingredient",
//                 MealIngredientAmount = 20,
//                 KitchenIngredientAmount = 50
//             }
//         ];
//
//         _mealIngredientRepository.GetMealIngredients(MealNames).Returns(ingredients);
//     }
//     private void WhenGetIngredientsListIsCalled()
//     {
//         _result = _subject.GetIngredientsList(MealNames);
//     }
//
//     private void ThenItShouldReturnTheIngredientsList()
//     {
//         _result.ShouldNotBeEmpty();
//         _result.Count.ShouldBe(1);
//         _result[0].RequiredIngredientAmount.ShouldBe(70);
//     }
//     
//     private void ThenItShouldReturnAnEmptyList()
//     {
//         _result.ShouldBeEmpty();
//     }
//
//
// }
