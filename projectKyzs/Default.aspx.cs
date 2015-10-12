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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TopPictureNewsRep.DataSource = new PicNewsManage().QueryTopPicNews();
            TopPictureNewsRep.DataBind();
            PictureNewsRep.DataSource = new PicNewsManage().QueryPicNews();
            PictureNewsRep.DataBind();
            PolicyPagesRep.DataSource = new DocsManage().QueryDocs("1");
            PolicyPagesRep.DataBind();
            PlanPagesRep.DataSource = new DocsManage().QueryDocs("2");
            PlanPagesRep.DataBind();
            InfoPagesRep.DataSource = new DocsManage().QueryDocs("3");
            InfoPagesRep.DataBind();
        }
        public string SubstringTitle(string str, int ind)
        {
            return new FunctionString().CutString(str, ind);
        }
        public string SubstringDate(string str)
        {
            string e = str.Substring(str.Length - 4, 4);
            string abb = "";
            if (e == "True")
            {
                abb = " TOP";
            }
            return new FunctionString().SubstringDate(str) + abb;
        }
        public string SubstringCompleteDate(string str)
        {
            string newstr = new FunctionString().SubstringDate(str);
            newstr = newstr.TrimEnd();
            string temp = newstr.Substring(1, 1);
            if (temp == "/")
            {
                newstr = "0" + newstr;
            }
            temp = newstr.Substring(newstr.Length - 2, 1);
            if (temp == "/")
            {
                temp = newstr.Substring(newstr.Length - 1);
                newstr = newstr.Remove(newstr.Length - 1);
                newstr = newstr + "0" + temp;
            }
            return str.Substring(0, 4) + "/" + newstr;
        }
        public string QueryTopPictureNewsPic()
        {
            try
            {
                DataTable dt = new PicNewsManage().QueryTopPicNews();
                return dt.Rows[0]["picurl"].ToString();
            }
            catch (Exception)
            {
                return "#";
            }

        }
        public string QueryTopPictureNewsTitle()
        {
            try
            {
                DataTable dt = new PicNewsManage().QueryTopPicNews();
                return new FunctionString().CutString(dt.Rows[0]["title"].ToString(), 20);
            }
            catch (Exception)
            {
                return "An Empty Mistake Caused By Admin.";
            }

        }
        public string QueryTopPictureNewsId()
        {
            try
            {
                DataTable dt = new PicNewsManage().QueryTopPicNews();
                return "Picnews.aspx?pnid=" + dt.Rows[0]["id"].ToString();
            }
            catch (Exception)
            {
                return "#";
            }
        }
    }
}