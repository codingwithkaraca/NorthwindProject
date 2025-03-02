using Core.Utilities.Results;

namespace Core.Utilities.Business;

public class BusinessRules
{
    // logic = iş kuralları
    public static IResult Run(params IResult[] logics)
    {
        foreach (var logic in logics)
        {
            if (!logic.Success)
            {
                return logic;
            }
        }

        return null;
    }
}