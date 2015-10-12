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
    public partial class Picnews : System.Web.UI.Page
    {
        public string pnid = null;
        public static string filePaths = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            pnid = Request.QueryString["pnid"];
            if (pnid != null)
            {
                title.Visible = false;
                PicRep.DataSource = new PicNewsManage().QueryPicNews(pnid);
                PicRep.DataBind();
            }
            else
            {
                TopPicNews.DataSource = new PicNewsManage().QueryTopPicNews();
                TopPicNews.DataBind();
                PicTitle.DataSource = new PicNewsManage().QueryPicNews();
                PicTitle.DataBind();
            }
        }
        public string ReformStringDate(string str)
        {
            string e = str.Substring(str.Length - 4, 4);
            string abb = "";
            if (e == "True")
            {
                abb = " TOP";
                return str.Remove(str.Length - 5) + abb;
            }
            else return str.Remove(str.Length - 6) + abb;
        }
    }
}