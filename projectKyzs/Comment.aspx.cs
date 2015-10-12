using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace projectKyzs
{
    public partial class Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageSelector_Load();
                PageSelector.SelectedIndex = 0;
            }
            int i = PageSelector.SelectedIndex;
            QARep.DataSource = MakeTable((i * 10).ToString(), ((i + 1) * 10 - 1).ToString());
            QARep.DataBind();
        }
        protected void PostQA_Click(object sender, EventArgs e)
        {
            string studentname = name.Text.Trim();
            string province = prov.SelectedValue.ToString();
            string text = Text.Text.Trim();
            bool i = false;
            if (studentname == "" || text == "")
                Response.Write("<script lang=javascript>alert('警告：有项目为空！')</script>");
            else
                i = new QAManage().CreateQA(studentname, province, text);
            if (i == true)
            {
                Response.Write("<script lang=javascript>alert('成功')</script>");
                name.Text = "";
                studentname = "";
                text = "";
                Text.Text = "";
                Response.Write("<script lang=javascript>window.location='Comment.aspx';</script>");
            }
            else
                Response.Write("<script lang=javascript>alert('失败，未知错误！')</script>");
            name.Text = "";
            prov.SelectedIndex = 0;
            Text.Text = "";
            QARep.DataSource = new QAManage().QueryCommentTable();
            QARep.DataBind();
        }
        public DataTable MakeTable(string startindex, string endindex)
        {
            int sindex = Convert.ToInt32(startindex);
            int eindex = Convert.ToInt32(endindex);
            DataTable newdt = new DataTable();
            newdt.Columns.Add("id");
            newdt.Columns.Add("author");
            newdt.Columns.Add("province");
            newdt.Columns.Add("question");
            newdt.Columns.Add("questime");
            newdt.Columns.Add("reply");
            newdt.Columns.Add("replytime");
            DataTable ori = new QAManage().QueryCommentTable();
            if (eindex + 1 > ori.Rows.Count)
            {
                eindex = ori.Rows.Count - 1;
            }
            for (; sindex <= eindex; sindex++)
            {
                if (ori.Rows[sindex] == null)
                    break;
                DataRow dtrow = newdt.NewRow();
                dtrow["id"] = ori.Rows[sindex]["id"].ToString();
                dtrow["author"] = ori.Rows[sindex]["author"].ToString();
                dtrow["province"] = ori.Rows[sindex]["province"].ToString();
                dtrow["question"] = ori.Rows[sindex]["question"].ToString();
                dtrow["questime"] = ori.Rows[sindex]["questime"].ToString();
                dtrow["reply"] = ori.Rows[sindex]["reply"].ToString();
                dtrow["replytime"] = ori.Rows[sindex]["replytime"].ToString();
                newdt.Rows.Add(dtrow);
            }
            return newdt;
        }
        public void PageSelector_Load()
        {
            PageSelector.Items.Clear();
            int count = (new QAManage().QueryCommentTable().Rows.Count);
            for (int i = 1; ; i++)
            {
                if (count - 10 > 0)
                {
                    PageSelector.Items.Add(new ListItem("第" + i + "页", i.ToString()));
                    count -= 10;
                }
                else
                {
                    PageSelector.Items.Add(new ListItem("第" + i + "页", i.ToString()));
                    break;
                }
            }
        }
        protected void PageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = PageSelector.SelectedIndex;
            QARep.DataSource = MakeTable((i * 10).ToString(), ((i + 1) * 10 - 1).ToString());
            QARep.DataBind();
        }
    }
}