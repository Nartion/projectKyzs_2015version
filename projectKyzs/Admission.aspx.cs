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
    public partial class Admission : System.Web.UI.Page
    {
        private string tableindex = null;//pageid = null
        private int pageindex = 1, pagetotal = 1, pagesintotal = 1;
        public string MainText = null, sTitle = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            AdmRep.DataSource = new FilesManage().QueryFileName();
            AdmRep.DataBind();
            pagesintotal = (new FilesManage().QueryFileName()).Rows.Count;
            pagetotal = pagesintotal / 10;
            if (pagesintotal % 10 != 0)
                pagetotal += 1;
            if (pageindex > pagetotal || pageindex < 0)
            {
                Response.Redirect("Admission.aspx");
            }
            DataTable sl = new DataTable();
            sl.Columns.Add("filename", Type.GetType("System.String"));
            for (int i = 0; i < pagetotal; i++)
            {
                sl.Rows.Add();
                sl.Rows[i]["filename"] = i + 1;
            }
            PageSelector.DataSource = sl;
            PageSelector.DataBind();
            SetCurrentPagelist();
        }
        public string ReturnTableID()
        {
            return tableindex;
        }
        public string ReturnPageIndex()
        {
            return pageindex.ToString();
        }
        public void SetCurrentPagelist()
        {
            //This is the total page count;
            //pagetotal;
            //This is the current page;
            //pageindex;
            if (pageindex > pagetotal || pageindex <= 0)
            {
                pageindex = 1;
            }
            int startindex = (pageindex - 1) * 4;
            int endindex = startindex;
            if (pageindex == pagetotal)
            {
                endindex = pagesintotal;
            }
            else endindex = startindex + 4;
            DataTable dt = new DataTable();
            dt.Columns.Add("filename", Type.GetType("System.String"));
            for (int i = 0; i < endindex - startindex; i++)
            {
                dt.Rows.Add();
                DataRow dr = new FilesManage().QueryFileName().Rows[startindex + i];
                dt.Rows[i]["filename"] = dr["filename"];
            }
            AdmRep.DataSource = dt;
            AdmRep.DataBind();
        }
        protected void npage_Click(object sender, EventArgs e)
        {
            if (pageindex < pagetotal)
                Response.Redirect("Pages.aspx?tid=" + tableindex + "&pageid=" + (pageindex + 1));
        }
        protected void ppage_Click(object sender, EventArgs e)
        {
            if (pageindex > 1)
                Response.Redirect("Pages.aspx?tid=" + tableindex + "&pageid=" + (pageindex - 1));
        }
    }
}