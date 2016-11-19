using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assignment5
{
    public partial class Signin_UserControl_Tryit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.signIn.subscribeToLoginButton(this.LoginHandler);
            this.signIn.subscribeToRegisterButton(this.RegisterHandler);
        }

        public void LoginHandler(string username, string password, EventArgs e)
        {
            this.lor.Text = string.Format("Logged in! username: {0} | password: {1}", username, password);
        }

        public void RegisterHandler(string username, string password, EventArgs e)
        {
            this.lor.Text = string.Format("Registering! username: {0} | password: {1}", username, password);
        }
    }
}