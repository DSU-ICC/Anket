﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logger
{
    public class FileLogger : ILogger, IDisposable
    {
        readonly string filePath;
        static readonly object _lock = new();
        public FileLogger(string path)
        {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
                    TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                if (logLevel > LogLevel.Warning || logLevel > LogLevel.Error || logLevel > LogLevel.Critical)
                    File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine + DateTime.Now + '\t');
            }
        }
    }
}
