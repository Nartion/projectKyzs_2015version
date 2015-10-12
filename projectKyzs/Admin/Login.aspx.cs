using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace projectKyzs.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
        protected void Checkin_Click(object sender, EventArgs e)
        {
            string adn = Username.Text.Trim();
            adn = Server.UrlEncode(adn);
            string pwd = Userpwd.Text.Trim();
            pwd = new GetMD5().GetValue(pwd);
            bool i = false;
            i = new userManage().Login_Check(adn, pwd);
            if (i == true)
            {
                Page.Session["adn"] = adn;
                Response.Redirect("Manage.aspx");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('登录失败！请检查后重试')</script>");
                Userpwd.Focus();
            }
        }
    }
}