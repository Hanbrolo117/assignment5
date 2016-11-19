using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace assignment5.Protected
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            try
            {
                if (File.Exists(fLocation))
                {
                    fs = new FileStream(fLocation, FileMode.Open, FileAccess.Read);
                    XmlDocument xd = new XmlDocument();
                    xd.Load(fs);
                    fs.Close();
                    XmlNode node = xd["Staffs"];
                    XmlNodeList children = node.ChildNodes;

                    foreach (XmlNode child in children)
                    {
                        txtStaffs.Text += child["userName"].InnerText + "\n";
                    }
                }
            }
            finally
            {
                fs.Close();
            }
        }

        protected void btnAddStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffRegister.aspx");
        }
    }
}