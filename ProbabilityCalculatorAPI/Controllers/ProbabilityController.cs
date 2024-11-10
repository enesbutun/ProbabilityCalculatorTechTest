using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProbabilityCalculatorAPI.Exceptions;
using ProbabilityCalculatorAPI.Model;
using ProbabilityCalculatorAPI.Services;

namespace ProbabilityCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/probabilities")]
    public class ProbabilityController : ControllerBase
    {

        private readonly IProbabilityService _probabilityService;
        private readonly ILogService _logService;
        private readonly ILogger<ProbabilityController> _logger;

        public ProbabilityController(IProbabilityService probabilityService,
                                      ILogService logService,
                                      ILogger<ProbabilityController> logger)
        {
            _probabilityService = probabilityService;
            _logService = logService;
            _logger = logger;
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([FromBody] ProbabilityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                double result = _probabilityService.PerformCalculation(request);


                var logEntry = _logService.CreateLogEntry(request.Operation.ToString(), request.ProbabilityA, request.ProbabilityB, result);


                await _logService.LogCalculationAsync(logEntry);

                return Ok(new ProbabilityResponse { Result = result });
            }
            catch (ArgumentException ex)
            { 
                return BadRequest(ex.Message); 
            }
            catch (UnsupportedOperationException ex)
            {
                _logger.LogWarning(ex, "Unsupported operation: {Operation}", request.Operation);

                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message} {ex.StackTrace}");

                _logger.LogError(ex, "Unexpected error occurred during calculation.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred."); 
            }
        }
    }
}