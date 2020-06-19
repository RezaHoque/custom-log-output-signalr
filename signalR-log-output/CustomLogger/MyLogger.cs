using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using signalR_log_output.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalR_log_output.CustomLogger
{
    public class MyLogger : ILogger
    {
        private readonly string _name;
        private readonly MyLoggerConfiguration _config;
        private readonly IHubContext<LogHub> _hubContext;

        public MyLogger(string name, MyLoggerConfiguration config, IHubContext<LogHub> hubContex)
        {
            _name = name;
            _config = config;
            _hubContext = hubContex;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
              _hubContext.Clients.All.SendAsync("Notification", "My Logger", $"{logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)}");
            }
        }
    }
}
