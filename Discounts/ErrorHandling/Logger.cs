using log4net;

namespace CartCalculator.Logger
{
    //logger for error handling
    public static class Logger
    {
        public static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
