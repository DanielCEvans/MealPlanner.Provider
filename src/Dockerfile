# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the entire solution into the build context
COPY . ./

# Set the working directory to the Endpoint project
WORKDIR /app/MealPlanner.Provider.Endpoint

# Restore dependencies for the Endpoint project
RUN dotnet restore

# Build the Endpoint project
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/MealPlanner.Provider.Endpoint/out .

# Expose the port your application will run on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "MealPlanner.Provider.Endpoint.dll"]