namespace takafulmath.Model
{
    public class MathInput
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // For logging
        public required string AlphaNum1 { get; set; }
        public required string AlphaNum2 { get; set; }
        public required string MathematicalSymbol { get; set; }
        private DateTime CreatedDatetime { get; set; } = DateTime.UtcNow;
        private DateTime UpdatedDatetime { get; set; } = DateTime.UtcNow;
    }
}
