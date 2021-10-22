using Autofac;
using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatorBuilder = new ContainerBuilder();
            calculatorBuilder.RegisterType<CalculatorApi>().As<ISimpleCalculator>();
            calculatorBuilder.RegisterType<Diagnostics>().As<IDiagnostics>();
            calculatorBuilder.RegisterType<DBSave>().As<IDBSave>();
            var calculatorContainer = calculatorBuilder.Build();
            var calculator = calculatorContainer.Resolve<ISimpleCalculator>();

            var webCalculatorBuilder = new ContainerBuilder();
            webCalculatorBuilder.RegisterType<CalculatorWeb>().As<ICalculatorWeb>();
            webCalculatorBuilder.RegisterType<Diagnostics>().As<IDiagnostics>();
            webCalculatorBuilder.RegisterType<DBSave>().As<IDBSave>();
            var calculatorWebContainer = webCalculatorBuilder.Build();
            var calculatorWeb = calculatorWebContainer.Resolve<ICalculatorWeb>();

            // IDiagnostics diagnostics = new Diagnostics();
            // IDBSave dbSave = new DBSave();
            // CalculatorApi calculator = new CalculatorApi(diagnostics, dbSave);
            // CalculatorWeb calculatorWeb = new CalculatorWeb(diagnostics, dbSave);

            string calculatorType, operation;
            int firstNum, secondNum, result;

            while (true)
            {
                Console.Write("Please Select The Type Of Calculator To Use (Web/Internal/Exit): ");
                calculatorType = Convert.ToString(Console.ReadLine());

                if (calculatorType.ToLower() == "exit")
                {
                    break;
                }

                Console.Write("Please Select The Operation To Perform (Add/Subtract/Multiply/Divide): ");
                operation = Convert.ToString(Console.ReadLine());

                Console.Write("Please Enter The First Number: ");
                firstNum = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter The Second Number: ");
                secondNum = Convert.ToInt32(Console.ReadLine());

                if (calculatorType.ToLower() == "web")
                {
                    switch (operation.ToLower())
                    {
                        case "add":
                            result = calculatorWeb.getAdd(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        case "subtract":
                            result = calculatorWeb.getSubtract(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        case "multiply":
                            result = calculatorWeb.getMultiply(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        case "divide":
                            result = calculatorWeb.getDivide(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        default:
                            Console.WriteLine("Invalid Operation Provided");
                            break;
                    }
                }
                else if (calculatorType.ToLower() == "internal")
                {
                    switch (operation.ToLower())
                    {
                        case "add":
                            result = calculator.Add(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        case "subtract":
                            result = calculator.Subtract(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        case "multiply":
                            result = calculator.Multiply(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        case "divide":
                            result = calculator.Divide(firstNum, secondNum);
                            Console.WriteLine("The Result is: " + result);
                            break;

                        default:
                            Console.WriteLine("Invalid Operation Provided");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Calculator Type Selected");
                }

                Console.ReadLine();
            }
        }
    }
}