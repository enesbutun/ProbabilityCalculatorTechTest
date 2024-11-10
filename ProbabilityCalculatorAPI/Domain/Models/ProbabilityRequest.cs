using System.ComponentModel.DataAnnotations;

namespace ProbabilityCalculatorAPI.Model
{
    public class ProbabilityRequest
    {
        [Range(0, 1, ErrorMessage = "ProbabilityA must be between 0 and 1.")]
        public double ProbabilityA { get; set; }

        [Range(0, 1, ErrorMessage = "ProbabilityB must be between 0 and 1.")]
        public double ProbabilityB { get; set; }

        [Required(ErrorMessage = "Operation is required.")]
       // [EnumOperationType(typeof(OperationType))]
        public OperationType Operation { get; set; }  
    }
}
