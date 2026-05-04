using takafulmath.Model;

namespace takafulmath.Interfaces
{
    public interface IMathInput
    {
        Task<string> TakafulMathInput(MathInputDTO mathInputDTO);
    }
}
