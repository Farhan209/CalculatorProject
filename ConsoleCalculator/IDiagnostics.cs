namespace ConsoleCalculator
{
    public interface IDiagnostics
    {
        void Log(string message);
        void Log();
    }
}
