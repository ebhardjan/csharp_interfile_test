using System.Diagnostics;
using System.Web;

class Program {
    public void sql_injection() {
        string queryParam = HttpContext.Current.Request.Form["queryParam"];
        BadSink sink = new BadSink();
        sink.bad_sink(queryParam);
    }
    public static void sql_no_injection() {
        string queryParam = HttpContext.Current.Request.Form["queryParam"];
        SanitizedSink.sanitized_sink(queryParam);
    }
    public void sql_injection_indirect() {
        string queryParam = HttpContext.Current.Request.Form["queryParam"];
        BadSink sink = new BadSink();
        Utils u = new Utils();
        string taintedParam = u.propagateTaint(queryParam);
        sink.bad_sink(taintedParam);
    }
    public static void sql_no_injection_no_propagation() {
        string queryParam = HttpContext.Current.Request.Form["queryParam"];
        BadSink sink = new BadSink();
        Utils u = new Utils();
        string immaculateParam = u.doesNotPropagateTaint(queryParam);
        SanitizedSink.sanitized_sink(immaculateParam);
    }
}
