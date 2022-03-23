using Serilog.Core;
using Serilog.Events;
using System.Reflection;

namespace dCaf.Logging.Enrichers
{
    public class ApplicationNameEnricher : ILogEventEnricher
    {
        private LogEventProperty? _applicationNameProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._applicationNameProperty ??= propertyFactory.CreateProperty("ApplicationName", Assembly.GetEntryAssembly().GetName().Name, false);
            logEvent.AddPropertyIfAbsent(this._applicationNameProperty);
        }
    }
}
