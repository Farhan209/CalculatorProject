using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class CalculatorWeb : ICalculatorWeb
    {
        private readonly IDiagnostics log = null;
        private readonly IDBSave databaseSave = null;

        public CalculatorWeb(IDiagnostics diagnostics, IDBSave dbSave)
        {
            this.log = diagnostics;
            this.databaseSave = dbSave;
        }

        public void GetLog(string message)
        {
            log.Log(message);
        }

        public void GetLog()
        {
            log.Log();
        }

        public int getAdd(int firstNumber, int secondNumber)
        {
            string firstNum = firstNumber.ToString();
            string secondNum = secondNumber.ToString();
            var output = Task.Run(() => Add(firstNum, secondNum));
            GetLog("Web Addition Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Web Addition: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Web Addition: " + output.Result);
            return output.Result;
        }

        static async Task<int> Add(string firstNumber, string secondNumber)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44349/");
                var resultAPI = await httpClient.GetAsync("api/Calculator/Add/?firstNumber=" + firstNumber + "&secondNumber=" + secondNumber);
                string resultString = await resultAPI.Content.ReadAsStringAsync();
                int resultInt = Convert.ToInt32(resultString);
                return resultInt;
            }
        }

        public int getDivide(int firstNumber, int secondNumber)
        {
            string firstNum = firstNumber.ToString();
            string secondNum = secondNumber.ToString();
            if (secondNumber == 0)
            {
                GetLog("Web Division By 0 Not Allowed");
                // databaseSave.SaveEFModel(DateTime.Now + " -- Error - Web Division By 0");
                databaseSave.SaveSP(DateTime.Now + " -- Error - Web Division By 0");
                return 0;
            }
            var output = Task.Run(() => Divide(firstNum, secondNum));
            GetLog("Web Division Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Web Division: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Web Division: " + output.Result);
            return output.Result;
        }

        static async Task<int> Divide(string firstNumber, string secondNumber)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44349/");
                var resultAPI = await httpClient.GetAsync("api/Calculator/Divide/?firstNumber=" + firstNumber + "&secondNumber=" + secondNumber);
                string resultString = await resultAPI.Content.ReadAsStringAsync();
                int resultInt = Convert.ToInt32(resultString);
                return resultInt;
            }
        }

        public int getMultiply(int firstNumber, int secondNumber)
        {
            string firstNum = firstNumber.ToString();
            string secondNum = secondNumber.ToString();
            var output = Task.Run(() => Multiply(firstNum, secondNum));
            GetLog("Web Multiplication Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Web Multiplication: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Web Multiplication: " + output.Result);
            return output.Result;
        }

        static async Task<int> Multiply(string firstNumber, string secondNumber)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44349/");
                var resultAPI = await httpClient.GetAsync("api/Calculator/Multiply/?firstNumber=" + firstNumber + "&secondNumber=" + secondNumber);
                string resultString = await resultAPI.Content.ReadAsStringAsync();
                int resultInt = Convert.ToInt32(resultString);
                return resultInt;
            }
        }

        public int getSubtract(int firstNumber, int secondNumber)
        {
            string firstNum = firstNumber.ToString();
            string secondNum = secondNumber.ToString();
            var output = Task.Run(() => Subtract(firstNum, secondNum));
            GetLog("Web Subtraction Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Web Subtraction: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Web Subtraction: " + output.Result);
            return output.Result;
        }

        static async Task<int> Subtract(string firstNumber, string secondNumber)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44349/");
                var resultAPI = await httpClient.GetAsync("api/Calculator/Subtract/?firstNumber=" + firstNumber + "&secondNumber=" + secondNumber);
                string resultString = await resultAPI.Content.ReadAsStringAsync();
                int resultInt = Convert.ToInt32(resultString);
                return resultInt;
            }
        }
    }
}
