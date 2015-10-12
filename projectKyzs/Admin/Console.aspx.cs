using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace projectKyzs.Admin
{
    public partial class Console : System.Web.UI.Page
    {
        public static string adminname = null, checkcode = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            adminname = Convert.ToString(Session["adn"]);
            checkcode = Request.QueryString["checkcode"];
            if (adminname == null || checkcode == null)
            {
                Response.Redirect("Manage.aspx");
            }
            RelogText.Text = "现在，请输入当前管理员密码";
        }
        protected void Exit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void Check_Button_Click(object sender, EventArgs e)
        {
            string pwd = Pwd.Text.Trim();
            pwd = new GetMD5().GetValue(pwd);
            bool i = new userManage().Login_Check(adminname, pwd);
            if (i == false)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            Response.Write("<script lang=javascript>alert('校验成功！')</script>");
            InitializdPage();
        }
        public void InitializdPage()
        {
            CreateTable.Visible = false;
            Create_name.Visible = false;
            Create_pwd.Visible = false;
            RelogText.Visible = false;
            Check_Button.Visible = false;
            Pwd.Visible = false;
            AdminSelector.Visible = true;
            Create.Visible = true;
            AdminSelector.Visible = true;
            DataTable dt = new userManage().QueryUserTable();
            int count = dt.Rows.Count;
            AdminSelector.Items.Clear();
            for (int j = 0; j < count; j++)
            {
                AdminSelector.Items.Add(new ListItem(dt.Rows[j]["admin_acccount"].ToString(), dt.Rows[j]["admin_acccount"].ToString()));
            }
            Text.Visible = true;
            Edit.Visible = true;
            this.Delete.Visible = true;
            ConfirmEdit.Visible = false;
            Freeze.Visible = true;
            AdminSelectorText.Visible = true;
            AdminIndicator.Visible = true;
            Status.Visible = true;
            AdminIndicator.Text = dt.Rows[AdminSelector.SelectedIndex]["admin_acccount"].ToString();
            Status.Text = ReturnStatus();
        }
        protected void AdminSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new userManage().QueryUserTable();
            AdminIndicator.Text = dt.Rows[AdminSelector.SelectedIndex]["admin_acccount"].ToString();
            Status.Text = ReturnStatus();
        }
        protected void Create_Click(object sender, EventArgs e)
        {
            CreateTable.Visible = true;
            Create_name.Visible = true;
            Create_pwd.Visible = true;
            Confirm.Visible = true;
            Text.Visible = false;
            Edit.Visible = false;
            Delete.Visible = false;
            Freeze.Visible = false;
            AdminSelector.Visible = false;
            AdminIndicator.Visible = false;
            AdminSelectorText.Visible = false;
            GoBack.Visible = true;
        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            string name = Create_name.Text.Trim();
            string pwd = Create_pwd.Text.Trim();
            pwd = new GetMD5().GetValue(pwd);
            bool i = new userManage().Set_Admin(name, pwd, adminname);
            if (i == true)
                Response.Write("<script lang=javascript>alert('创建成功！')</script>");
            else
                Response.Write("<script lang=javascript>alert('创建失败！')</script>");
            InitializdPage();
        }
        protected void GoBack_Click(object sender, EventArgs e)
        {
            GoBack.Visible = false;
            InitializdPage();
            CreateTable.Visible = false;
            Create_name.Visible = false;
            Create_pwd.Visible = false;
            Confirm.Visible = false;
            Status.Text = ReturnStatus();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            bool i = new userManage().DeleteUser(AdminIndicator.Text.Trim());
            if (i == true)
            {
                Response.Write("<script lang=javascript>alert('成功！')</script>");
                InitializdPage();
            }
            else Response.Write("<script lang=javascript>alert('失败！')</script>");
        }
        protected void Freeze_Click(object sender, EventArgs e)
        {
            bool i = new userManage().FreezeAdmin(AdminIndicator.Text.Trim(), adminname);
            if (i == true)
            {
                Response.Write("<script lang=javascript>alert('成功！')</script>");
                InitializdPage();
            }
            else Response.Write("<script lang=javascript>alert('失败！')</script>");
            Status.Text = ReturnStatus();
        }
        public string ReturnStatus()
        {
            DataTable dt = new userManage().QueryUserTable();
            string i = dt.Rows[AdminSelector.SelectedIndex]["admin_actived"].ToString();
            return (i == "True") ? "当前激活" : "冻结中";
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Delete.Visible = false;
            Freeze.Visible = false;
            Create_name.Visible = true;
            Create_name.ReadOnly = true;
            Create_name.Text = AdminSelector.SelectedValue.ToString();
            Create_pwd.Visible = true;
            CreateTable.Focus();
            CreateTable.Visible = true;
            ConfirmEdit.Visible = true;
        }
        protected void ConfirmEdit_Click(object sender, EventArgs e)
        {
            string name = AdminSelector.SelectedValue.ToString();
            bool i = false;
            string pwd = Create_pwd.Text.Trim();
            pwd = new GetMD5().GetValue(pwd);
            i = new userManage().EditAdmin(name, pwd, AdminSelector.SelectedValue.ToString());
            if (i == true)
                Response.Write("<script lang=javascript>alert('修改成功！')</script>");
            else
                Response.Write("<script lang=javascript>alert('修改失败！')</script>");
            Create_name.ReadOnly = false;
            Create_name.Text = null;
            InitializdPage();
        }
    }
}