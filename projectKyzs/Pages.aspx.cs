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
    public partial class Pages : System.Web.UI.Page
    {
        private string tableindex = null, pageid = null;
        private int pageindex = 1, pagetotal = 1, pagesintotal = 1;
        public string MainText = null, sTitle = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Convert.ToInt32(Request.QueryString["pageid"]);
            tableindex = Request.QueryString["tid"];
            pageid = Request.QueryString["pid"];
            if (tableindex == null || pageid == "-1")
            {
                Response.Redirect("Default.aspx");
            }
            if (pageid != null)
            {
                try
                {
                    DataTable pagedt = new DocsManage().QueryDoc(pageid);
                    MainText = pagedt.Rows[0]["text"].ToString();
                    sTitle = pagedt.Rows[0]["title"].ToString();
                }
                catch (Exception)
                {
                    throw;
                }

                paginator.Visible = false;
                conter_title.Visible = false;
                conter_nav.Visible = false;
            }
            else
            {
                paginator.Visible = true;
                conter_title.Visible = true;
                conter_nav.Visible = true;
                conter_text.Visible = false;
                conter_texttitle.Visible = false;
                DataTable pagedt = new DocsManage().QueryDocs(tableindex);
                TablePagesRep.DataSource = pagedt;
                TablePagesRep.DataBind();
                MainText = null;
                sTitle = null;
            }
            pagesintotal = (new DocsManage().QueryDocs(tableindex)).Rows.Count;
            pagetotal = pagesintotal / 10;
            if (pagesintotal % 10 != 0)
                pagetotal += 1;
            DataTable sl = new DataTable();
            sl.Columns.Add("pageid", Type.GetType("System.Int32"));
            for (int i = 0; i < pagetotal; i++)
            {
                sl.Rows.Add();
                sl.Rows[i]["pageid"] = i + 1;
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
        public string ReturnTitle()
        {
            switch (tableindex)
            {
                case "1": return "招生政策";
                case "2": return "招生计划";
                case "3": return "录取分数";
                case "4": return "入学指南";
                default: return "**没有此条目，请检查后再试**";
            }
        }
        public string ReturnTextTitle()
        {
            return sTitle;
        }
        public string ReturnMainText()
        {
            return MainText;
        }
        public string SubstringTitle(string str, int ind)
        {
            return new FunctionString().CutString(str, ind);
        }
        public string SubstringCompleteDate(string str)
        {
            return str.Substring(0, 4) + "/" + new FunctionString().SubstringDate(str);
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
            int startindex = (pageindex - 1) * 10;
            int endindex = startindex;
            if (pageindex == pagetotal)
            {
                endindex = pagesintotal;
            }
            else endindex = startindex + 10;
            DataTable dt = new DataTable();
            dt.Columns.Add("pageid", Type.GetType("System.Int32"));
            dt.Columns.Add("id", Type.GetType("System.String"));
            dt.Columns.Add("title", Type.GetType("System.String"));
            dt.Columns.Add("text", Type.GetType("System.String"));
            dt.Columns.Add("time", Type.GetType("System.String"));
            for (int i = 0; i < endindex - startindex; i++)
            {
                dt.Rows.Add();
                try
                {
                    DataRow dr = new DocsManage().QueryDocs(tableindex).Rows[startindex + i];
                    dt.Rows[i]["pageid"] = dr["pageid"];
                    dt.Rows[i]["id"] = dr["id"];
                    dt.Rows[i]["title"] = dr["title"];
                    dt.Rows[i]["text"] = dr["text"];
                    dt.Rows[i]["time"] = dr["time"];
                }
                catch (Exception)
                {
                    dt.Rows[0]["pageid"] = "1";
                    dt.Rows[0]["id"] = "-1";
                    dt.Rows[i]["title"] = "Empty";
                    dt.Rows[i]["text"] = "Empty";
                    dt.Rows[i]["time"] = "1970/1/1 00:00:01";
                    break;
                }
            }
            TablePagesRep.DataSource = dt;
            TablePagesRep.DataBind();
        }
        protected void npage_Click(object sender, EventArgs e)
        {
            if (pageindex < pagetotal)
                Response.Redirect("Pages.aspx?tid=" + tableindex + "&pageid=" + (pageindex + 1));
        }
        protected void ppage_Click(object sender, EventArgs e)
        {
            if (pageindex > 0)
                Response.Redirect("Pages.aspx?tid=" + tableindex + "&pageid=" + (pageindex - 1));
        }
    }
}