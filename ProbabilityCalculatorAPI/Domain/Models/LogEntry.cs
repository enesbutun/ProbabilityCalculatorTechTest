namespace ProbabilityCalculatorAPI.Model
{
    public class LogEntry
    {
        public string? Operation { get; set; }
        public double ProbabilityA { get; set; }
        public double ProbabilityB { get; set; }
        public double Result { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now; 
    }
}
