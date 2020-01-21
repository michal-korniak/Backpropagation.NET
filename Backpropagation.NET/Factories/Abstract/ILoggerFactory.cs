using Backpropagation.NET.Loggers.Abstract;

namespace Backpropagation.NET.Factories.Abstract
{
    public interface ILoggerFactory
    {
        ILogger Create(string loggerName);
    }
}