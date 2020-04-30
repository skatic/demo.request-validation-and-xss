using System;

namespace RequestValidationAndXss
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //unencoded
                Label1.Text = TextBox1.Text;

                //encoded example
                //Label1.Text = Server.HtmlEncode(TextBox1.Text);
            }
        }
    }
}