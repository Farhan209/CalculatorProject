using System;

namespace ConsoleCalculator
{
    public class Diagnostics : IDiagnostics
    {
        public void Log(string message)
        {
            Console.WriteLine("Log: " + message);        
        }

        public void Log()
        {
            // no log message
        }
    }
}
