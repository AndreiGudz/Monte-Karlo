// Класс ответственный за логирование сообщений и ошибок

namespace Monte_Karlo.Utilites
{
    public class Logger
    {
        private string logDir = Path.Combine(Application.StartupPath, "Logs");

        // Метод для логирования сообщений
        public void Log(string message)
        {
            string logFile = Path.Combine(logDir, DateTime.Now.ToString("yyyy-MM-dd") + ".log");

            try
            {
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                string line = $"[{timestamp}] {message}";

                File.AppendAllText(logFile, line + Environment.NewLine);
                System.Diagnostics.Debug.WriteLine("[LOG] " + line);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[LOG ERROR] " + ex.Message);
                LogException(ex, message);
            }
        }

        // Метод для логирования ошибок
        public void LogException(Exception exception, string message = "")
        {
            System.Diagnostics.Debug.WriteLine($"[ERROR] {message} {exception.Message}\n{exception.StackTrace}");

            string logFile = Path.Combine(logDir, DateTime.Now.ToString("error") + ".log");

            try
            {
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd - HH:mm:ss");
                string line = $"[{timestamp}] {message} {exception.Message}\n{exception.StackTrace}";

                File.AppendAllText(logFile, line + Environment.NewLine);
                System.Diagnostics.Debug.WriteLine("[LOG] " + line);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[LOG ERROR] " + ex.Message);
            }
        }
    }
}
