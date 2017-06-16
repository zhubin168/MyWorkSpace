using GiveU.Infrastructure.Logging;

namespace Dafy.OnlineTran.Common
{
    public static class LoggerWrapper
    {
        private static ILogger _logger;
        public static ILogger Logger
        {
            get { return _logger; }
        }

        public static void InitLogger(ILogger logger)
        {
            _logger = logger;
        }
    }
}
