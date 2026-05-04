using FluentValidation;
using takafulmath.Model;
namespace takafulmath.Validation
{
    public class MathInputValidator : AbstractValidator<MathInputDTO>
    {
        private static readonly HashSet<string> ValidOperators = new()
        {
            "+",   // Addition
            "-",   // Subtraction
            "*",   // Multiplication
            "/",   // Division
            "%",   // Modulo
            "^",   // Exponentiation
            "**"   // Exponentiation (alternate)
        };

        private static readonly System.Text.RegularExpressions.Regex AlphanumericRegex =
            new(@"^[a-zA-Z0-9]+$", System.Text.RegularExpressions.RegexOptions.Compiled);

        public MathInputValidator()
        {
            RuleFor(x => x.AlphaNum1)
                .NotEmpty()
                    .WithMessage("AlphaNum1 is required.")
                .Matches(AlphanumericRegex)
                    .WithMessage("AlphaNum1 must contain only alphanumeric characters (a-z, A-Z, 0-9).");

            RuleFor(x => x.AlphaNum2)
                .NotEmpty()
                    .WithMessage("AlphaNum2 is required.")
                .Matches(AlphanumericRegex)
                    .WithMessage("AlphaNum2 must contain only alphanumeric characters (a-z, A-Z, 0-9).");

            RuleFor(x => x.Operator)
                .NotEmpty()
                    .WithMessage("Operator is required.")
                .Must(op => ValidOperators.Contains(op))
                    .WithMessage($"Operator must be one of: {string.Join(", ", ValidOperators)}");
        }
    }
}
