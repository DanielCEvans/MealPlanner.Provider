# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build

# Create a directory for the source code
WORKDIR /source

# http
EXPOSE 80
# https
EXPOSE 443

# Copy csproj files
COPY "MealPlanner.Provider.Endpoint/*.csproj" "MealPlanner.Provider.Endpoint/"
COPY "MealPlanner.Provider.Persistence/*.csproj" "MealPlanner.Provider.Persistence/"

# Install the required dependencies for the application
# The Persistence library is a dependency of the Endpoint project
RUN dotnet restore "MealPlanner.Provider.Endpoint/MealPlanner.Provider.Endpoint.csproj"

# Copy the source code
COPY "MealPlanner.Provider.Endpoint/" "MealPlanner.Provider.Endpoint/"
COPY "MealPlanner.Provider.Persistence/" "MealPlanner.Provider.Persistence/"
WORKDIR "/source/MealPlanner.Provider.Endpoint"
 
# Build app and libraries 
# The -o specifies the directory for the output files from the dotnet publish command
# The publish command compiles the application and includes the following assets:
# - Intermediate Language (IL) code in an assembly with a dll extension
# - deps.json file with all of the dependencies of the project
# - .runtimeconfig.json file that specifies the shared runtime that the app expects
# - The applications dependencies
# The output from this command is ready for deployment to a hosting system (server, Mac, PC)
# for execution. 
RUN dotnet publish -o /out

# final stage/image
FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-jammy-chiseled-composite
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet","MealPlanner.Provider.Endpoint.dll"]