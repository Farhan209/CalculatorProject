using System.Web.Http;

namespace CalculatorWebAPI.Controllers
{
    public class CalculatorController : ApiController
    {
        // ../api/Calculator/Add
        [HttpGet]
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        // ../api/Calculator/Subtract
        [HttpGet]
        public int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        // ../api/Calculator/Multiply
        [HttpGet]
        public int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        // ../api/Calculator/Divide
        [HttpGet]
        public int Divide(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                return 0;
            }
            return firstNumber / secondNumber;
        }

        // ../api/Controller
        [HttpGet]
        public string Get()
        {
            return "Please Select One Of The Operations (Add/Subtract/Multiply/Divide)";
        }
    }
}
