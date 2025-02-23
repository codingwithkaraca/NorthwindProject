using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool 
{
    
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            var failure = string.Join(Environment.NewLine, result.Errors.Select(e => e.ErrorMessage));
            throw new FluentValidation.ValidationException(failure);
        }
        
        
        /*if (!result.IsValid)
        {
            var failures = result.Errors;
            throw new ValidationException(failures);
        }*/
        
        /*return result.IsValid ? new List<string>() : result.Errors.Select(e => e.ErrorMessage).ToList();*/
    }
}