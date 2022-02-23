using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Diagnostics;
namespace TopOneApi.Controllers
{
    public class logErreur
    {
        public static void trace_erreur(Exception ex, string msg)
        {

            string filename = "log_api_TopOne_" + DateTime.Today.ToShortDateString().Replace("/", "_");

            if (!Directory.Exists("c:\\AGSoft\\log"))
            {
                Directory.CreateDirectory("c:\\AGSoft\\log");
            }
            string chemin_log = "c:\\AGSoft\\log\\" + filename + ".txt";
            File.AppendAllText(chemin_log, " \n " + DateTime.Now + ":" + ex.Message + "/" + msg + ex.StackTrace.ToString() + "\n");
            //System.Diagnostics.Trace.Listeners.Add(new TextWriterTraceListener("c:\\clinisys\\log\\" + filename + ".log", "myListener"));
            //System.Diagnostics.Trace.TraceError(DateTime.Now.ToString() + ":" + ex.Message.ToString() + ex.StackTrace.ToString());
            //// You must close or flush the trace to empty the output buffer.
            //System.Diagnostics.Trace.Flush();
        }
        public static void trace_erreur(Exception ex)
        {

            string filename = "log_api_AGSoft_" + DateTime.Today.ToShortDateString().Replace("/", "_");

            if (!Directory.Exists("c:\\AGSoft\\log"))
            {
                Directory.CreateDirectory("c:\\AGSoft\\log");
            }
            string chemin_log = "c:\\AGSoft\\log\\" + filename + ".txt";
            File.AppendAllText(chemin_log, " \n " + DateTime.Now + ":" + ex.Message + ex.StackTrace.ToString() + "\n");
        }
    }
}