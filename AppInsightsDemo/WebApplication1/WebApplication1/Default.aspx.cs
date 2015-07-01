using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //To programmatically set your instrumentation key:
            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings.Get("AppInsightKey");
            TelemetryClient telemetry = new TelemetryClient();

            /*
             Use TrackEvent when:
              -Each specific event is important – you can view them in Diagnostic Search.
              -Metrics are measured with each event, so that you can segment the metrics by event type and properties of the event.
              -Users/sessions centric metrics are important for the event for e.g. if you want to know the region from which users are uploading files 
               (enables you to make a decision about getting a processing server in that region)
            */
            telemetry.TrackEvent("Karbyn-Test-Event");

            /*
             Tracks a custom trace
              -Use this to help diagnose problems by sending a 'breadcrumb trail' to Application Insights. 
              -You can send chunks of diagnostic data, and inspect them in Diagnostic search.
              -This, and exceptions, are accessible under diagnostics search (start by clicking on search, then filters on the top
            */
            telemetry.TrackTrace("Karbyn-Test-Trace");


            /*
            Use TrackMetric when:
              -The metric is independent of any specific event.
              -You want to measure things on specific intervals (such as CPU or queue length every minute).
              -You have a high volume of metrics and would like to collect and aggregate locally before sending it.   
            */
            telemetry.TrackMetric("Karbyn-Test-Metric", new Random(100).NextDouble());


            //Tracks an exception - accessible under diagnostics search as well            
            //Although AppInsights will track your errors automatically, here I can associate this error with a particular correlation ID, giving me access to this id within App Insights.
            var propertiesDictionary = new Dictionary<string, string>();
            telemetry.Properties.Add("correlation-id", "3ggbbg45-b812-1234-1ce1-a51cb3241b4g");
            telemetry.
            telemetry.TrackException(new DivideByZeroException());
        }
    }
}