namespace MealPlanner.Provider.Endpoint.Helpers;

public class UnitConverter
{
    private readonly Dictionary<string, Func<decimal, int>> _conversionDictionary;
    
    public UnitConverter()
    {
        _conversionDictionary = new Dictionary<string, Func<decimal, int>>
        {
            { "kg - g", KgToGm },
            { "tbs - g", TbsToGm },
            { "tsp - g", TspToGm },
            { "l - ml", LtToMl },
            { "cup - ml", CupToMl },
            { "tbs - ml", TbsToMl },
            { "tsp - ml", TspToMl },
        };
    }
    
    private int KgToGm(decimal value)
    {
        return (int)Math.Round(value * 1000);
    }
    
    private int TbsToGm(decimal value)
    {
        return (int)Math.Round(value * 15);
    }
    
    private int TspToGm(decimal value)
    {
        return (int)Math.Round(value * 5);
    }
    
    private int LtToMl(decimal value)
    {
        return (int)Math.Round(value * 1000);
    }

    private int CupToMl(decimal value)
    {
        return (int)Math.Round(value * 250);
    }
    
    private int TbsToMl(decimal value)
    {
        return (int)Math.Round(value * 15);
    }
    
    private int TspToMl(decimal value)
    {
        return (int)Math.Round(value * 5);
    }

    public int Convert(string fromToUnit, decimal value)
    {
        return _conversionDictionary[fromToUnit](value);
    }
}