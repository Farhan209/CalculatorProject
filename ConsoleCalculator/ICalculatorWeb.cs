namespace ConsoleCalculator
{
    interface ICalculatorWeb
    {
        int getAdd(int firstNumber, int secondNumber);
        int getSubtract(int firstNumber, int secondNumber);
        int getMultiply(int firstNumber, int secondNumber);
        int getDivide(int firstNumber, int secondNumber);
    }
}
