using Ganss.XSS;
using System;

namespace RequestValidationAndXss
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var sanitizer = new HtmlSanitizer();
                var sanitized = sanitizer.Sanitize(TextBox1.Text);

                //unencoded
                Label1.Text = sanitized;

                //encoded example
                //Label1.Text = Server.HtmlEncode(TextBox1.Text);
            }
        }
    }
}