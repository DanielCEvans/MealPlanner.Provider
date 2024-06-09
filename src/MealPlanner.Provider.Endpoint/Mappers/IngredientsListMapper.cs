using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

// public class IngredientsListMapper : IIngredientListMapper
// {
//     public IngredientsList MealIngredientsToIngredientsList(List<MealIngredients> mealIngredients)
//     {
//         Dictionary<string, int> ingredientsListAsDictionary = new Dictionary<string, int>();
//         
//         foreach (MealIngredients mealIngredient in mealIngredients)
//         {
//             if (ingredientsListAsDictionary.ContainsKey(mealIngredient.IngredientName))
//             {
//                 ingredientsListAsDictionary[mealIngredient.IngredientName] += (mealIngredient.MealIngredientAmount);
//             }
//             else
//             {
//                 ingredientsListAsDictionary.Add(mealIngredient.IngredientName, mealIngredient.MealIngredientAmount);
//             }
//         }
//
//         IngredientsList ingredientsList = new IngredientsList();
//         foreach (var ingredientName in ingredientsListAsDictionary.Keys)
//         {
//             Ingredient ingredient = new Ingredient()
//             {
//                 IngredientName = ingredientsListAsDictionary
//             }
//         }
//         return ingredientsList;
//     }
// }