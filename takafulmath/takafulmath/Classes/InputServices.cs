using takafulmath.Interfaces;
using takafulmath.Model;
using takafulmath.Validation;

namespace takafulmath.Classes
{
    public class InputServices: IMathInput
    {
        private readonly MathInputValidator _validator;

        public InputServices(MathInputValidator validator)
        {
            _validator = validator;
        }

        public async Task<string> TakafulMathInput(MathInputDTO mathInputDTO)
        {
            var validationResult = await _validator.ValidateAsync(mathInputDTO);

            if (!validationResult.IsValid)
                throw new FluentValidation.ValidationException(validationResult.Errors);

            var model = new MathInput
            {
                AlphaNum1 = mathInputDTO.AlphaNum1,
                AlphaNum2 = mathInputDTO.AlphaNum2,
                MathematicalSymbol = mathInputDTO.Operator
            };

            // MISSED: Returned output
            var returnedExpression = $"{model.AlphaNum1} {model.MathematicalSymbol} {model.AlphaNum2}";
            return await Task.FromResult(returnedExpression);
        }
    }
}