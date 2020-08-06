using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningAspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET: api/<controller>/sum
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber)) {
                string result = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)).ToString();
                return Ok(result);
            }

            return BadRequest("invalid input");

        }

        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                string result = (ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber)).ToString();
                return Ok(result);
            }

            return BadRequest("invalid input");

        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                string result = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber)).ToString();
                return Ok(result);
            }

            return BadRequest("invalid input");

        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                string result = (ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber)).ToString();
                return Ok(result);
            }

            return BadRequest("invalid input");

        }

        [HttpGet("square/{number}")]
        public IActionResult Square(string number) {
            if (isNumeric(number)){
                var result = Math.Sqrt(ConvertToDouble(number)).ToString();
                return Ok(result);
            }


            return BadRequest("invalid input");
        }



        private double ConvertToDouble(string number)
        {

            double convertedNumber = 0;

            double.TryParse(number, out convertedNumber);

            return convertedNumber;
        }

        private decimal ConvertToDecimal(string number) {

            decimal convertedNumber = 0;

            decimal.TryParse(number, out convertedNumber);

            return convertedNumber;
        }


        private bool isNumeric(string number) {
            double convertedNumber;

            return double.TryParse(number, 
                                    System.Globalization.NumberStyles.Any, 
                                    System.Globalization.NumberFormatInfo.InvariantInfo, 
                                    out convertedNumber
                                  );
        }
    }
}
