using Serilog.Core;
using Serilog.Events;
using System;
using System.Diagnostics;

namespace dCaf.Logging.Enrichers
{
    public class DiagnosticActivityEnricher : ILogEventEnricher
    {
        //TODO: allow to log W3C formatted activity id as well as older requestId style 
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent is null) throw new ArgumentNullException(nameof(logEvent));

            var activity = Activity.Current;
            if (activity is null) return;
            var traceIdProperty = new LogEventProperty("TraceId", new ScalarValue(activity.TraceId));
            logEvent.AddPropertyIfAbsent(traceIdProperty);

            var parentIdProperty = new LogEventProperty("ParentId", new ScalarValue(activity.ParentId));
            logEvent.AddPropertyIfAbsent(parentIdProperty);

        }
    }
}
