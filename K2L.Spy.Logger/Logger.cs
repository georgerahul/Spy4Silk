using System.Collections.ObjectModel;

namespace K2L.Spy.Logger
{
    public class Logger
    {
        private uint _counter;
        private static readonly object _lockObject = new object();
        private static Logger _logger;
        public ObservableCollection<LogData> Logs { get; private set; }

        public static Logger GetLogger()
        {
            _logger = _logger ?? new Logger();
            return _logger;
        }

        private Logger()
        {
            _counter = 0;
            Logs = new ObservableCollection<LogData>();
        }

        public void WriteLog(string log)
        {
            lock (_lockObject)
            {
                Logs.Add(new LogData()
                {
                    Count = _counter++,
                    Text = log
                });
            }
        }
    }

    public class LogData
    {
        public uint Count { get; set; }
        public string Text { get; set; }
    }
}