using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using signalR_log_output.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalR_log_output.CustomLogger
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly MyLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, MyLogger> _loggers = new ConcurrentDictionary<string, MyLogger>();
        private readonly IHubContext<LogHub> _hubContext;


        public MyLoggerProvider(MyLoggerConfiguration configuration, IHubContext<LogHub> hubContex)
        {
            _config = configuration;
            _hubContext = hubContex;
        }
        
        public ILogger CreateLogger(string categoryName)
        {
           return _loggers.GetOrAdd(categoryName, name => new MyLogger(name, _config,_hubContext));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
