### Learnings Along The Way

#### Database migrations:

remember when applying migrations and updating the datbase using ef core to specifiy the --project and --startup-project\
e.g. dotnet ef migrations add AddUniqueConstraintToUserIngredient --project MealPlanner.Provider.Persistence/ --startup-project MealPlanner.Provider.Endpoint\
dotnet ef database update --project MealPlanner.Provider.Persistence/ --startup-project MealPlanner.Provider.Endpoint