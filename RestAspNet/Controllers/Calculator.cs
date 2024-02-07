using Microsoft.AspNetCore.Mvc;

namespace RestAspNet.Controllers
{
    public class Calculator : Controller
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            try {
                var sum = Convert.ToInt32(firstNumber) + Convert.ToInt32(secondNumber);

                return Ok(sum);
            } catch (FormatException) { 
                return BadRequest("Digite apenas valores numéricos");
            }
        }

        [HttpGet("minus/{firstNumber}/{secondNumber}")]
        public IActionResult Minus(string firstNumber, string secondNumber)
        {
            try
            {
                var sum = Convert.ToInt32(firstNumber) - Convert.ToInt32(secondNumber);

                return Ok(sum);
            }
            catch (FormatException)
            {
                return BadRequest("Digite apenas valores numéricos");
            }
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            try
            {
                var sum = Convert.ToInt32(firstNumber) * Convert.ToInt32(secondNumber);

                return Ok(sum);
            } catch (FormatException) {
                return BadRequest("Digite apenas valores numéricos");
            }
        }

        [HttpGet("divide/{firstNumber}/{secondNumber}")]
        public IActionResult divide(string firstNumber, string secondNumber)
        {
            try
            {
                var sum = Convert.ToInt32(firstNumber) / Convert.ToInt32(secondNumber);

                return Ok(sum);
            }
            catch (FormatException)
            {
                return BadRequest("Digite apenas valores numéricos");
            }
        }
    }
}
