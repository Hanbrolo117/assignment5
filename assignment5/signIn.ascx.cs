using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assignment5
{
    public partial class signIn : System.Web.UI.UserControl
    {
        public delegate void Login(string username, string password, EventArgs e);
        public event Login login_instance;
        public event Login register_instance;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_event_Click(object sender, EventArgs e)
        {
            //Emit Login Event to subscribers:
            this.login_instance(this.username_input.Text, this.password_input.Text, e);
        }

        public void subscribeToLoginButton(Action<string, string, EventArgs> app_handler) {
            //Subscribe to a login event:
            this.login_instance += new Login(app_handler);
        }

        public void subscribeToRegisterButton(Action<string, string, EventArgs> app_handler) {
            //Subscribe to a register event:
            this.register_instance += new Login(app_handler);
        }

        protected void register_event_Click(object sender, EventArgs e)
        {
            //May have entered in username and password, pass this to event handler and fill register fields with this as a suggestion to save time:
            string username = "";
            string password = "";
            if (this.username_input.Text.Length > 0) {
                username = this.username_input.Text;
            }
            if (this.password_input.Text.Length > 0) {
                password = this.password_input.Text;
            }

            //Emit Register Event to subscribers:
            this.register_instance(username, password, e);
        }
    }
}