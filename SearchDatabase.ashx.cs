using System.Web;

namespace RequestValidationAndXss
{
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";

            string queryparam1 = context.Request["queryparam1"];

            context.Response.Write("Searching databse with:<br />");
            context.Response.Write("queryparam1: " + queryparam1);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}