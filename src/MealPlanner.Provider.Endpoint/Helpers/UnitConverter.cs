namespace MealPlanner.Provider.Endpoint.Helpers;

public class UnitConverter
{
    private readonly Dictionary<string, Func<int, int>> _conversionDictionary;
    
    public UnitConverter()
    {
        _conversionDictionary = new Dictionary<string, Func<int, int>>
        {
            { "kgs - gms", KgsToGms },
            { "tbs - grams", TbsToGrams },
            { "tsp - grams", TspToGrams },
            { "lts - mls", LtsToMls },
            { "cups - mls", CupsToMls },
            { "tbs - mls", TbsToMls },
            { "tsp - mls", TspToMls },
        };
    }
    
    private int KgsToGms(int value)
    {
        return value * 1000;
    }
    
    private int TbsToGrams(int value)
    {
        return value * 15;
    }
    
    private int TspToGrams(int value)
    {
        return value * 5;
    }
    
    private int LtsToMls(int value)
    {
        return value * 1000;
    }

    private int CupsToMls(int value)
    {
        return value * 250;
    }
    
    private int TbsToMls(int value)
    {
        return value * 15;
    }
    
    private int TspToMls(int value)
    {
        return value * 5;
    }

    public int Convert(string fromToUnit, int value)
    {
        return _conversionDictionary[fromToUnit](value);
    }
}