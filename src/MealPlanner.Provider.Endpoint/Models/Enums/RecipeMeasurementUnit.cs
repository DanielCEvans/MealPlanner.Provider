using System.Text.Json.Serialization;

namespace MealPlanner.Provider.Endpoint.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RecipeMeasurementUnit
{
    kg,
    gm,
    l,
    ml,
    cup,
    tbs,
    tsp,
    singular
}