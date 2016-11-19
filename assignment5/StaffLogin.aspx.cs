using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using ourLibrary;

namespace assignment5
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.signIn.subscribeToLoginButton(this.LoginHandler);
            this.signIn.subscribeToRegisterButton(this.RegisterHandler);
        }

        public void LoginHandler(string username, string password, EventArgs e)
        {
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            XmlNode node = XMLProccess.findUser(fLocation, username);
            if (node == null)
            {
                lor.Text = "User does not exist";
            }else if (string.Compare(node["password"].InnerText, password) != 0)
            {
                lor.Text = "wrong Password";
            }
            else
                lor.Text = "Login Sucess!";

        }

        public void RegisterHandler(string username, string password, EventArgs e)
        {
            this.lor.Text = string.Format("Registering! username: {0} | password: {1}", username, password);
        }
    }
}