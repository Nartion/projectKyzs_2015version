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
    public partial class Pictures : System.Web.UI.Page
    {
        public int pageindex = 1;
        private static int pagesintotal = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string pid = Request.QueryString["pid"];
            if (pid != null && pid != "")
            {
                pageindex = Convert.ToInt32(pid);
            }
            if (pageindex > pagesintotal)
            {
                Response.Redirect("Pictures.aspx");
            }
            SetPages();
            LoadPics();
        }
        public void LoadPics()
        {
            if (pageindex > pagesintotal)
            {
                pageindex = pagesintotal;
            }
            picturesRep.DataSource = MakeTable(((pageindex - 1) * 20).ToString(), (pageindex * 20 - 1).ToString());
            picturesRep.DataBind();
            CheckStatus();
        }
        public DataTable MakeTable(string startindex, string endindex)
        {
            int sindex = Convert.ToInt32(startindex);
            int eindex = Convert.ToInt32(endindex);
            DataTable newdt = new DataTable();
            newdt.Columns.Add("picurl");
            newdt.Columns.Add("id");
            DataTable ori = new PicturesManage().QueryPictures();
            if (eindex + 1 > ori.Rows.Count)
            {
                eindex = ori.Rows.Count - 1;
            }
            for (; sindex <= eindex; sindex++)
            {
                if (sindex < 0)
                    break;
                if (ori.Rows[sindex] == null)
                    break;
                int tempi = sindex;
                DataRow dtrow = newdt.NewRow();
                dtrow["picurl"] = ori.Rows[sindex]["picurl"].ToString();
                dtrow["id"] = ori.Rows[sindex]["id"].ToString();
                newdt.Rows.Add(dtrow);
                sindex = tempi;
            }
            return newdt;
        }
        public void CheckStatus()
        {
            if (pageindex == pagesintotal)
            {
                NextPage.Enabled = false;
            }
            else NextPage.Enabled = true;
            if (pageindex <= 1)
            {
                pageindex = 1;
                PreviousPage.Enabled = false;
            }
            else
                PreviousPage.Enabled = true;
        }
        protected void NextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pictures.aspx?pid=" + (pageindex + 1));
        }
        protected void PreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pictures.aspx?pid=" + (pageindex - 1));
        }
        public void SetPages()
        {
            int count = (new PicturesManage().QueryPictures().Rows.Count);
            pagesintotal = 1;
            for (int i = 1; ; i++)
            {
                if (count - 20 > 0)
                {
                    pagesintotal++;
                    count -= 20;
                }
                else
                {
                    break;
                }
            }
        }
        public string ReturnPageIndex()
        {
            return pageindex.ToString();
        }
        public string ReturnPagesIntotal()
        {
            return pagesintotal.ToString();
        }
    }
}