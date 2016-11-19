using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using ourLibrary;

namespace assignment5.Protected
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] list;
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            list = XMLProccess.getUserList(fLocation);
            for(int i = 0; i < list.Length; i++)
            {
                txtStaffs.Text += (list[i] + "\n");
            }
        }

        protected void btnAddStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffRegister.aspx");
        }
    }
}