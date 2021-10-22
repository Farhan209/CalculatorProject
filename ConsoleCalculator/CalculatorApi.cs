using System;

namespace ConsoleCalculator
{
    class CalculatorApi : ISimpleCalculator
    {
        private readonly IDiagnostics log = null;
        private readonly IDBSave databaseSave = null;

        public CalculatorApi(IDiagnostics diagnostics, IDBSave dbSave)
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

        public int Add(int firstNumber, int secondNumber)
        {
            int result = firstNumber + secondNumber;
            GetLog("Addition Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Addition: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Addition: " + result);
            return result;
        }

        public int Divide(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                GetLog("Division By 0 Not Allowed");
                // databaseSave.SaveEFModel(DateTime.Now + " -- Error - Division By 0");
                databaseSave.SaveSP(DateTime.Now + " -- Error - Division By 0");
                return 0;
            }
            int result = firstNumber / secondNumber;
            GetLog("Division Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Division: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Division: " + result);
            return result;
        }

        public int Multiply(int firstNumber, int secondNumber)
        {
            int result = firstNumber * secondNumber;
            GetLog("Multiplication Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Multiplication: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Multiplication: " + result);
            return result;
        }

        public int Subtract(int firstNumber, int secondNumber)
        {
            int result = firstNumber - secondNumber;
            GetLog("Subtraction Result Calculated");
            // databaseSave.SaveEFModel(DateTime.Now + " -- Subtraction: " + result);
            databaseSave.SaveSP(DateTime.Now + " -- Subtraction: " + result);
            return result;
        }
    }
}
