namespace takafulmath.Model
{
    public class MathInputDTO
    {
        public required string AlphaNum1 { get; set; }
        public required string AlphaNum2 { get; set; }
        public required string Operator { get; set; }
        public MathInputDTO() { }
        public MathInputDTO(MathInput mathinput)
        {
            AlphaNum1 = mathinput.AlphaNum1;
            AlphaNum2 = mathinput.AlphaNum2;
            Operator = mathinput.MathematicalSymbol;
        }
    }
}
