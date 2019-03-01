using NLog;

namespace CertificatesModel.LoggingService
{
    public static class LoggingService
    {
        private static Logger _logger;

        static LoggingService()
        {
            _logger = _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Логирование событий
        /// </summary>
        /// <param name="message">Описание события</param>
        public static void LogEvent(string message)
        {
            _logger.Info(message);
        }

        /// <summary>
        /// Логирование ошибки
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public static void LogError(string message)
        {
            _logger.Error(message);
        }
    }
}
