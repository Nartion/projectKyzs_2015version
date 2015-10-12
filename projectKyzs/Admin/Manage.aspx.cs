using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using DAL2;
using Model;
using System.IO;

namespace projectKyzs.Admin
{
    public partial class Manage : System.Web.UI.Page
    {
        private static string Instructions = null, adminname = null, picnewsfilename = "", pageid = null, docid = null, defaultuploadpath = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            adminname = Convert.ToString(Session["adn"]);
            adminname = Server.UrlDecode(adminname);
            bool i = false;
            if (Session["adn"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                Instructions = "欢迎进入后台管理系统，在这里您可以对整个科技学院招生网站进行控制与监管。";
                InitializePage("");
            }
            i = new userManage().CheckLevel(adminname);
            if (i == true)
            {
                admin.Visible = false;
                bool p = new userManage().IsNotFrozen(adminname);
                if (p != true)
                {
                    Response.Write("<script lang=javascript>alert('你的管理员账户已经被冻结！')</script>");
                    kyxc.Visible = false;
                    kyxw.Visible = false;
                    lqxx.Visible = false;
                    zszc.Visible = false;
                    zsjh.Visible = false;
                    zsxx.Visible = false;
                    rxzn.Visible = false;
                    kswd.Visible = false;
                    Instructions = "被冻结的管理员账户，将暂时失去所有权限！请联系最高管理员解除限制！";
                }
                else Instructions = "欢迎管理员访问，请根据列表对系统进行管理。";
            }
            else
            {
                admin.Visible = true;
            }
        }

        #region 页面加载相关操作
        public void InitializePage()
        {
            SuperDelete.Visible = false;
            RefreshButton.Visible = false;
            lqUpload.Enabled = true;
            PicturesUpload.Visible = false;
            PicturesReplace.Visible = false;
            PicturesDelete.Visible = false;
            QAReply.Visible = false;
            PicturesSelector.Visible = false;
            QA_Reply.Visible = false;
            QA_Ignore.Visible = false;
            QAText.Visible = false;
            QADpl.Visible = false;
            Functions.Visible = false;
            ManageLink.Visible = false;
            TitlePlace.Visible = false;
            TextPlace.Visible = false;
            TitleBox.Visible = false;
            tbContent.Visible = false;
            Docdl.Visible = false;
            docdpl.Visible = false;
            FileUploadButton.Visible = false;
            OntopDpl.Visible = false;
            FileUpload.Visible = false;
            PicNewsInstruction.Visible = false;
            submit_News.Visible = false;
            submit_Edit.Visible = false;
            submit_CreateDoc.Visible = false;
            submit_EditDoc.Visible = false;
            picnewsdpl.Visible = false;
            lqUpload.Visible = false;
            Upload.Visible = false;
            MessageLbl.Visible = false;
            FileDpl.Visible = false;
            imgb1.Visible = false;
            imgb2.Visible = false;
            imgb3.Visible = false;
            ConfirmReplace1.Visible = false;
            ConfirmReplace2.Visible = false;
            ConfirmReplace3.Visible = false;
            DeleteFile.Visible = false;
            CleartbContent();
        }
        public void InitializePage(string a)
        {
            SuperDelete.Visible = false;
            RefreshButton.Visible = false;
            lqUpload.Enabled = true;
            PicturesSelector.Visible = false;
            PicturesUpload.Visible = false;
            PicturesReplace.Visible = false;
            PicturesDelete.Visible = false;
            QAReply.Visible = false;
            QA_Reply.Visible = false;
            QA_Ignore.Visible = false;
            QAText.Visible = false;
            QADpl.Visible = false;
            Functions.Visible = false;
            TitlePlace.Visible = false;
            ManageLink.Visible = false;
            TextPlace.Visible = false;
            TitleBox.Visible = false;
            tbContent.Visible = false;
            Docdl.Visible = false;
            docdpl.Visible = false;
            FileUploadButton.Visible = false;
            OntopDpl.Visible = false;
            FileUpload.Visible = false;
            PicNewsInstruction.Visible = false;
            submit_News.Visible = false;
            submit_Edit.Visible = false;
            submit_CreateDoc.Visible = false;
            submit_EditDoc.Visible = false;
            picnewsdpl.Visible = false;
            lqUpload.Visible = false;
            Upload.Visible = false;
            FileDpl.Visible = false;
            imgb1.Visible = false;
            imgb2.Visible = false;
            imgb3.Visible = false;
            ConfirmReplace1.Visible = false;
            ConfirmReplace2.Visible = false;
            ConfirmReplace3.Visible = false;
            MessageLbl.Visible = false;
            DeleteFile.Visible = false;
            CleartbContent();
        }
        public string ReturnAdminName()
        {
            return adminname;
        }
        public void CleartbContent()
        {
            tbContent.Text = "";
        }
        public string ReturnInstructions()
        {
            return Instructions;
        }
        protected void Exit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        #endregion

        #region 科院相册相关事件
        protected void kyxc_Click(object sender, EventArgs e)
        {
            InitializePage();
            PicturesUpload.Visible = true;
            PicturesReplace.Visible = true;
            PicturesDelete.Visible = true;
            PicturesSelector.Visible = true;
            RefreshButton.Visible = true;
            imgb1.Visible = true;
            imgb2.Visible = true;
            imgb3.Visible = true;
            ConfirmReplace1.Visible = true;
            ConfirmReplace2.Visible = true;
            ConfirmReplace3.Visible = true;
            Functions.Visible = true;
            Functions.Text = "科院相册";
            Instructions = "在此，您可以对科院相册中的各个图片文件进行重定向，同时修改主页展示的三张图片。";
            defaultuploadpath = "~/img/";
            lqUpload.Visible = true;
            MessageLbl.Visible = true;
            InitializePictures();
        }
        protected void ConfirmReplace1_Click(object sender, EventArgs e)
        {
            if (lqUpload.HasFile)
            {
                lqUpload.SaveAs(Server.MapPath(defaultuploadpath) + "show1.png");
                MessageLbl.Text = "成功修改：" + lqUpload.FileName;
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert(上传成功！);", true);
                //Response.Write("<script lang=javascript>alert('上传成功！')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert(上传失败！);", true);
                //Response.Write("<script lang=javascript>alert('上传失败！')</script>");
            }
        }
        protected void ConfirmReplace2_Click(object sender, EventArgs e)
        {
            if (lqUpload.HasFile)
            {
                lqUpload.SaveAs(Server.MapPath(defaultuploadpath) + "show2.png");
                MessageLbl.Text = "成功修改：" + lqUpload.FileName;
                Response.Write("<script lang=javascript>alert('上传成功！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('上传失败！')</script>");
            }
        }
        protected void ConfirmReplace3_Click(object sender, EventArgs e)
        {
            if (lqUpload.HasFile)
            {
                lqUpload.SaveAs(Server.MapPath(defaultuploadpath) + "show3.png");
                MessageLbl.Text = "成功修改：" + lqUpload.FileName;
                Response.Write("<script lang=javascript>alert('上传成功！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('上传失败！')</script>");
            }
        }
        protected void PicturesUpload_Click(object sender, EventArgs e)
        {
            if (defaultuploadpath == "abc")
            {
                goto a;
            }
            defaultuploadpath = "~/images/";
            int count = Convert.ToInt32(new PicturesManage().QueryPictures().Rows.Count);
            int lastindex;
            if (count == 0)
            {
                lastindex = 0;
            }
            else lastindex = Convert.ToInt32(new PicturesManage().QueryPictures().Rows[count - 1]["id"]);
            string filetodb = "images/" + (lastindex + 1).ToString() + ".jpg";
            if (!lqUpload.HasFile)
            {
                Response.Write("<script lang=javascript>alert('上传失败！')</script>");
            }
            else
            {
                lqUpload.SaveAs(Server.MapPath(defaultuploadpath) + (lastindex + 1).ToString() + ".jpg");
                MessageLbl.Text = "成功上传：" + lqUpload.FileName;
                if (new PicturesManage().AddPicture(filetodb, (lastindex + 1).ToString()))
                {
                    Response.Write("<script lang=javascript>alert('上传成功！如果要继续上传，请点击上方刷新按钮，键盘F5刷新会引起上传！')</script>");
                }
                else
                    Response.Write("<script lang=javascript>alert('上传失败！')</script>");
            }
            defaultuploadpath = "abc";
        a: InitializePictures();
        }
        protected void PicturesReplace_Click(object sender, EventArgs e)
        {
            defaultuploadpath = "~/images/";
            int count = Convert.ToInt32(new PicturesManage().QueryPictures().Rows.Count);
            int selectedindex = Convert.ToInt32(PicturesSelector.SelectedValue.ToString());
            if (lqUpload.HasFile)
            {
                lqUpload.SaveAs(Server.MapPath(defaultuploadpath) + selectedindex.ToString() + ".jpg");
                MessageLbl.Text = "成功上传：" + lqUpload.FileName;
                Response.Write("<script lang=javascript>alert('替换成功！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('替换失败！')</script>");
            }
            InitializePictures();
        }
        protected void PicturesDelete_Click(object sender, EventArgs e)
        {
            int itemtodelete = Convert.ToInt32(PicturesSelector.SelectedValue);
            bool i = new PicturesManage().Delete(itemtodelete.ToString());
            int index = Convert.ToInt32(PicturesSelector.SelectedValue.ToString());
            string file = index.ToString() + ".jpg";
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "images\\";
            File.Delete(path + file);
            if (i == true)
            {
                Response.Write("<script lang=javascript>alert('删除成功！')</script>");
            }
            else
                Response.Write("<script lang=javascript>alert('删除失败！')</script>");
            InitializePictures();
        }
        public void InitializePictures()
        {
            DataTable dt = new PicturesManage().QueryPictures();
            int count = dt.Rows.Count;
            PicturesSelector.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                PicturesSelector.Items.Add(new ListItem(dt.Rows[i]["picurl"].ToString(), dt.Rows[i]["id"].ToString()));
            }
        }
        #endregion

        #region 录取信息相关操作
        /*protected void lqxx_Click(object sender, EventArgs e)
        {
            InitializePage();
            Functions.Visible = true;
            Functions.Text = "录取信息";
            Instructions = "在这里，您可以上传最新的、修正后的录取信息以供用户下载查看。";
            lqUpload.Visible = true;
            Upload.Visible = true;
            MessageLbl.Visible = true;
            FileDpl.Visible = true;
            DeleteFile.Visible = true;
            FileDpl.Items.Clear();
            DataTable fdt = new FilesManage().QueryFileName();
            int count = fdt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                FileDpl.Items.Add(new ListItem(fdt.Rows[i]["filename"].ToString(), fdt.Rows[i]["filename"].ToString()));
            }
            defaultuploadpath = "~/files/admissionscores/";
        }*/
        protected void Upload_Click(object sender, EventArgs e)
        {
            if (lqUpload.HasFile)
            {
                lqUpload.SaveAs(Server.MapPath(defaultuploadpath) + lqUpload.FileName);
                MessageLbl.Text = "成功上传：" + lqUpload.FileName;
            }
            bool i = new FilesManage().Upload(lqUpload.FileName);
            if (i == false)
            {
                Response.Write("<script lang=javascript>alert('上传失败！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('上传成功！')</script>");
            }
        }
        protected void DeleteFile_Click(object sender, EventArgs e)
        {
            if (FileDpl.Visible == true)
            {
                string name = FileDpl.SelectedValue.ToString();
                bool i = new FilesManage().Delete(name);
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "files\\admissionscores\\";
                File.Delete(path + FileDpl.Text.Trim());
                if (i == false)
                {
                    Response.Write("<script lang=javascript>alert('删除失败！')</script>");
                }
                else
                {
                    Response.Write("<script lang=javascript>alert('删除成功！')</script>");
                }
            }
        }
        #endregion


        public bool AnounceBlank()
        {
            Response.Write("<script lang=javascript>alert('警告！有项目为空！')</script>");
            return false;
        }


        #region 招生政策相关操作 pageid=1
        protected void zszc_Click(object sender, EventArgs e)
        {
            pageid = "1";
            InitializePage();
            RefreshButton.Visible = true;
            CleartbContent();
            SuperDelete.Visible = true;
            Functions.Visible = true;
            Functions.Text = "招生政策";
            Instructions = "这里，您可以通过非常直观的方式对科院今年的招生政策进行规范的修改。";
            TitlePlace.Visible = true;
            TitlePlace.Text = "页面标题";
            TitleBox.Visible = true;
            TextPlace.Visible = true;
            TextPlace.Text = "页面正文";
            tbContent.Visible = true;
            docdpl.Visible = true;
            Docdl.Visible = true;
            submit_CreateDoc.Visible = true;
            submit_EditDoc.Visible = true;
            docdpl.Items.Clear();
            DataTable dt = new DocsManage().QueryDocss("1");
            int i = dt.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                docdpl.Items.Add(new ListItem(dt.Rows[j]["id"].ToString(), dt.Rows[j]["id"].ToString()));
            }
            if (!Page.IsPostBack)
            {
                docdpl.SelectedIndex = 0;
            }
        }
        protected void submit_CreateDoc_Click(object sender, EventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string text = tbContent.Text.Trim();
            bool actived = (Docdl.SelectedIndex == 0) ? true : false;

            bool goon = true;
            if (text == "" || title == "")
                goon = AnounceBlank();


            bool i = goon == true ? (new DocsManage().PostDocs(title, text, actived, pageid)) : false;
            if (i == false)
            {
                Response.Write("<script lang=javascript>alert('发布失败！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('发布成功！')</script>");
                TitleBox.Text = "";
                title = "";
                text = "";
                tbContent.Text = "";
            }
        }
        protected void submit_EditDoc_Click(object sender, EventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string text = tbContent.Text.Trim();
            bool actived = (Docdl.SelectedIndex == 0) ? true : false;

            bool goon = true;
            if (text == "" || title == "")
                goon = AnounceBlank();

            bool i = goon == true ? (new DocsManage().EditDocs(title, text, actived, docid)) : false;
            if (i == false)
            {
                Response.Write("<script lang=javascript>alert('修改失败！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('修改成功！')</script>");
            }
        }
        protected void docdpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            docid = docdpl.SelectedValue;
            DataTable dt = new DocsManage().QueryDoc(docid);
            TitleBox.Text = dt.Rows[0]["title"].ToString();
            tbContent.Text = dt.Rows[0]["text"].ToString();
            Docdl.SelectedIndex = (dt.Rows[0]["actived"].ToString() == "True") ? 0 : 1;
        }
        #endregion

        #region 招生计划相关操作 pageid=2
        protected void zsjh_Click(object sender, EventArgs e)
        {
            pageid = "2";
            InitializePage();
            RefreshButton.Visible = true;
            SuperDelete.Visible = true;
            Functions.Visible = true;
            Functions.Text = "招生计划";
            Instructions = "您在这里对招生计划的每一处修改，都将完整呈现给每一位访客。";
            TitlePlace.Visible = true;
            TitlePlace.Text = "页面标题";
            TitleBox.Visible = true;
            TextPlace.Visible = true;
            TextPlace.Text = "页面正文";
            tbContent.Visible = true;
            docdpl.Visible = true;
            Docdl.Visible = true;
            submit_CreateDoc.Visible = true;
            submit_EditDoc.Visible = true;
            docdpl.Items.Clear();
            DataTable dt = new DocsManage().QueryDocss("2");
            int i = dt.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                docdpl.Items.Add(new ListItem(dt.Rows[j]["id"].ToString(), dt.Rows[j]["id"].ToString()));
            }
            if (!Page.IsPostBack)
            {
                docdpl.SelectedIndex = 0;
            }
        }
        #endregion

        #region 录取分数相关操作 pageid=3
        protected void zsxx_Click(object sender, EventArgs e)
        {
            pageid = "3";
            InitializePage();
            SuperDelete.Visible = true;
            RefreshButton.Visible = true;
            Functions.Visible = true;
            Functions.Text = "录取分数";
            Instructions = "录取分数，您可以随时修改。(请注意，如果您想要插入Excel或者Word当中的表格，请先插入表格，然后点击编辑器左上角的“源码”，将正文最前方的“border=“0”改成1，再次点击“源码”返回，即可继续添加文本，只有这样，添加的表格才能显示出边框。”)";
            TitlePlace.Visible = true;
            TitlePlace.Text = "页面标题";
            TitleBox.Visible = true;
            TextPlace.Visible = true;
            TextPlace.Text = "页面正文";
            tbContent.Visible = true;
            docdpl.Visible = true;
            Docdl.Visible = true;
            submit_CreateDoc.Visible = true;
            submit_EditDoc.Visible = true;
            docdpl.Items.Clear();
            DataTable dt = new DocsManage().QueryDocss("3");
            int i = dt.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                docdpl.Items.Add(new ListItem(dt.Rows[j]["id"].ToString(), dt.Rows[j]["id"].ToString()));
            }
            if (!Page.IsPostBack)
            {
                docdpl.SelectedIndex = 0;
            }
        }
        #endregion

        #region 入学指南相关操作 pageid=4
        protected void rxzn_Click(object sender, EventArgs e)
        {
            pageid = "4";
            InitializePage();
            SuperDelete.Visible = true;
            RefreshButton.Visible = true;
            Functions.Visible = true;
            Functions.Text = "入学指南";
            Instructions = "此处，您对新同学的每一句关切的问候，都能展现的淋漓尽致。";
            TitlePlace.Visible = true;
            TitlePlace.Text = "页面标题";
            TitleBox.Visible = true;
            TextPlace.Visible = true;
            TextPlace.Text = "页面正文";
            tbContent.Visible = true;
            docdpl.Visible = true;
            Docdl.Visible = true;
            submit_CreateDoc.Visible = true;
            submit_EditDoc.Visible = true;
            docdpl.Items.Clear();
            DataTable dt = new DocsManage().QueryDocss("4");
            int i = dt.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                docdpl.Items.Add(new ListItem(dt.Rows[j]["id"].ToString(), dt.Rows[j]["id"].ToString()));
            }
            if (!Page.IsPostBack)
            {
                docdpl.SelectedIndex = 0;
            }
        }
        #endregion

        #region 考生问答相关事件
        protected void kswd_Click(object sender, EventArgs e)
        {
            InitializePage();
            RefreshButton.Visible = false;
            QA_Reply.Visible = true;
            QAText.Visible = true;
            QADpl.Visible = true;
            QAReply.Visible = true;
            Functions.Visible = true;
            QA_Ignore.Visible = true;
            QAText.Text = "暂时没有任何提问";
            Functions.Text = "考生问答";
            Instructions = "孩子们和家长们的提问，您可以在这里管理（审核、回复）。";
            DataTable dt = new QAManage().QueryComments();
            int count = dt.Rows.Count;
            if (count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Error because of no questions detected!')", true);
            }
            if (count > 0)
            {
                QADpl.Items.Clear();
                for (int j = 0; j < count; j++)
                {
                    QADpl.Items.Add(new ListItem(dt.Rows[j]["author"].ToString(), dt.Rows[j]["id"].ToString()));
                }
                QADpl.SelectedIndex = 0;
                QAText.Text = dt.Rows[QADpl.SelectedIndex]["question"].ToString();
            }
            if (QADpl.Text.ToString() == null || QADpl.Text.ToString() == "")
                RefreshButton.Visible = false;
            else
                RefreshButton.Visible = true;
        }
        protected void QADpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new QAManage().QueryComments();
            QAText.Text = dt.Rows[QADpl.SelectedIndex]["question"].ToString();
        }
        protected void QA_Reply_Click(object sender, EventArgs e)
        {
            DataTable dts = new QAManage().QueryComments();
            if (dts.Rows.Count != 0)
            {
                string reply = QAReply.Text.Trim();
                bool i = new QAManage().Reply(reply, QADpl.SelectedValue.ToString());
                if (i == true)
                    Response.Write("<script lang=javascript>alert('成功！')</script>");
                else
                    Response.Write("<script lang=javascript>alert('失败！')</script>");
                DataTable dt = new QAManage().QueryComments();
                int count = dt.Rows.Count;
                QADpl.Items.Clear();
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        QADpl.Items.Add(new ListItem(dt.Rows[j]["author"].ToString(), dt.Rows[j]["id"].ToString()));
                    }
                    QADpl.SelectedIndex = 0;
                    QAText.Text = dt.Rows[QADpl.SelectedIndex]["question"].ToString();
                }
                QAReply.Text = "";
                QAText.Text = "";
            }
            else
                Response.Write("<script lang=javascript>alert('尚未制定对应项，操作失败！')</script>");
        }
        protected void QA_Ignore_Click(object sender, EventArgs e)
        {
            DataTable dts = new QAManage().QueryComments();
            if (dts.Rows.Count != 0)
            {
                bool i = new QAManage().Ignore(QADpl.SelectedValue.ToString());
                if (i == true)
                    Response.Write("<script lang=javascript>alert('成功！')</script>");
                else
                    Response.Write("<script lang=javascript>alert('失败！')</script>");
                DataTable dt = new QAManage().QueryComments();
                int count = dt.Rows.Count;
                QADpl.Items.Clear();
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        QADpl.Items.Add(new ListItem(dt.Rows[j]["author"].ToString(), dt.Rows[j]["id"].ToString()));
                    }
                    QADpl.SelectedIndex = 0;
                    QAText.Text = dt.Rows[QADpl.SelectedIndex]["question"].ToString();
                }
                QAReply.Text = "";
                QAText.Text = "";
            }
            else
                Response.Write("<script lang=javascript>alert('尚未指定对应项，操作失败！')</script>");
        }
        #endregion

        #region 管理员控制相关事件
        protected void admin_Click(object sender, EventArgs e)
        {
            InitializePage();
            RefreshButton.Visible = false;
            Functions.Visible = true;
            ManageLink.Visible = true;
            Functions.Text = "控制管理员";
            Instructions = "进入这里，您将可以对所有管理员进行控制（当然，我们会为了保护你而限制你的权力）。现在，请移步下述按钮进行管理，需要说明的是，当你点击后，需要你重新验证管理员密码。";
        }
        protected void ManageLink_Click(object sender, EventArgs e)
        {
            if (new userManage().CheckLevel(adminname) == false)
            {
                Response.Redirect("~/Admin/Console.aspx?checkcode=0");
            }
        }
        #endregion

        #region 招生信息相关事件
        protected void kyxw_Click(object sender, EventArgs e)
        {
            InitializePage();
            RefreshButton.Visible = true;
            SuperDelete.Visible = true;
            Functions.Visible = true;
            Functions.Text = "招生信息";
            Instructions = "此时，您可以发布带图片的招生信息，或是对它修改、删除，并对特别的信息项设置置顶。";
            TitlePlace.Visible = true;
            TextPlace.Visible = true;
            TitleBox.Visible = true;
            tbContent.Visible = true;
            OntopDpl.Visible = true;
            FileUpload.Visible = true;
            PicNewsInstruction.Visible = true;
            FileUploadButton.Visible = true;
            submit_News.Visible = true;
            submit_Edit.Visible = true;
            picnewsdpl.Visible = true;
            DataTable picnewsdt = new PicNewsManage().QueryAllPicNews();
            int indexlength = picnewsdt.Rows.Count;
            if (indexlength == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Nothing Detected!');", true);
            }
            else
            {
                for (int i = 0; i < indexlength; i++)
                {
                    picnewsdpl.Items.Add(new ListItem(picnewsdt.Rows[i]["id"].ToString(), picnewsdt.Rows[i]["id"].ToString()));
                }
            }
            if (!Page.IsPostBack)
            {
                picnewsdpl.SelectedIndex = 0;
            }
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                string fileExrensio = System.IO.Path.GetExtension(FileUpload.FileName).ToLower();//ToLower转化为小写
                string FileType = FileUpload.PostedFile.ContentType;
                string UploadURL = Server.MapPath("~/files/picnews/pics/");//上传的目录
                if (FileType == "image/bmp" || FileType == "image/gif" || FileType == "image/jpeg" || FileType == "image/jpg" || FileType == "image/png")//判断文件类型
                {
                    try
                    {
                        if (!System.IO.Directory.Exists(UploadURL))//判断文件夹是否已经存在
                        {
                            System.IO.Directory.CreateDirectory(UploadURL);//创建文件夹
                        }
                        picnewsfilename = "files/picnews/pics/" + FileUpload.FileName;
                        FileUpload.PostedFile.SaveAs(UploadURL + FileUpload.FileName);
                    }
                    catch
                    {
                        Response.Write("<script lang=javascript>alert('失败！')</script>");
                    }
                }
                else
                {
                    Response.Write("<script lang=javascript>alert('格式错误！')</script>");
                }
            }
            else
                Response.Write("<script lang=javascript>alert('请选择文件！')</script>");
        }
        protected void submit_News_Click(object sender, EventArgs e)
        {
            string newstitle = TitleBox.Text.Trim();
            string newstext = tbContent.Text.Trim();
            string ontop = OntopDpl.SelectedValue;
            bool i = false;
            if (ontop == "ontop")
            {
                i = true;
            }
            bool c = false;


            bool goon = true;
            if (newstitle == "" || newstext == "")
            {
                goon = AnounceBlank();
            }
            c = goon == true ? (new picNewsManage().PostPicNews(newstitle, newstext, picnewsfilename, i)) : false;
            if (c == false)
            {
                Response.Write("<script lang=javascript>alert('发布失败！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('发布成功！')</script>");
                TitleBox.Text = "";
                newstitle = "";
                newstext = "";
                tbContent.Text = "";
            }
        }
        protected void submit_Edit_Click(object sender, EventArgs e)
        {
            string picnewsid = picnewsdpl.SelectedValue;
            string title = TitleBox.Text.Trim();
            string text = tbContent.Text.Trim();
            bool ontop = (OntopDpl.SelectedIndex == 0) ? true : false;
            PicNewsClass picnews = new PicNewsClass();
            bool goon = true;
            if (title == "" || text == "")
            {
                goon = AnounceBlank();
            }

            bool i = (goon == true) ? (new picNewsManage().EditPicNews(title, text, ontop, picnewsid)) : false;
            if (i == false)
            {
                Response.Write("<script lang=javascript>alert('修改失败！')</script>");
            }
            else
            {
                Response.Write("<script lang=javascript>alert('修改成功！')</script>");
            }
        }
        protected void picnewsdpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string i = picnewsdpl.SelectedValue;
            TitleBox.Visible = true;
            TitleBox.Text = "123";
            TitleBox.Text = (new PicNewsManage().QueryPicNews(picnewsdpl.SelectedValue)).Rows[0]["title"].ToString();
            tbContent.Text = (new PicNewsManage().QueryPicNews(picnewsdpl.SelectedValue)).Rows[0]["details"].ToString();
            OntopDpl.SelectedIndex = ((new PicNewsManage().QueryPicNews(picnewsdpl.SelectedValue)).Rows[0]["ontop"].ToString() == "True") ? 0 : 1;
        }
        #endregion

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            if (docdpl.Visible == true)
            {
                docdpl.Items.Clear();
                DataTable dt = new DocsManage().QueryDocss(pageid);
                int i = dt.Rows.Count;
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        docdpl.Items.Add(new ListItem(dt.Rows[j]["id"].ToString(), dt.Rows[j]["id"].ToString()));
                    }
                    docid = docdpl.SelectedValue;
                    DataTable ndt = new DocsManage().QueryDoc(docid);
                    TitleBox.Text = ndt.Rows[0]["title"].ToString();
                    tbContent.Text = ndt.Rows[0]["text"].ToString();
                    Docdl.SelectedIndex = (ndt.Rows[0]["actived"].ToString() == "True") ? 0 : 1;
                }

            }
            if (picnewsdpl.Visible == true)
            {
                picnewsdpl.Items.Clear();
                DataTable picnewsdt = new PicNewsManage().QueryAllPicNews();
                int indexlength = picnewsdt.Rows.Count;
                if (indexlength > 0)
                {
                    for (int i = 0; i < indexlength; i++)
                    {
                        picnewsdpl.Items.Add(new ListItem(picnewsdt.Rows[i]["id"].ToString(), picnewsdt.Rows[i]["id"].ToString()));
                    }
                    TitleBox.Visible = true;
                    TitleBox.Text = "123";
                    TitleBox.Text = (new PicNewsManage().QueryPicNews(picnewsdpl.SelectedValue)).Rows[0]["title"].ToString();
                    tbContent.Text = (new PicNewsManage().QueryPicNews(picnewsdpl.SelectedValue)).Rows[0]["details"].ToString();
                    OntopDpl.SelectedIndex = ((new PicNewsManage().QueryPicNews(picnewsdpl.SelectedValue)).Rows[0]["ontop"].ToString() == "True") ? 0 : 1;

                }
            }
            if (Functions.Text == "科院相册")
            {
                defaultuploadpath = "~/images/";
            }
            if (FileDpl.Visible == true)
            {
                FileDpl.Items.Clear();
                DataTable fdt = new FilesManage().QueryFileName();
                int count = fdt.Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        FileDpl.Items.Add(new ListItem(fdt.Rows[i]["filename"].ToString(), fdt.Rows[i]["filename"].ToString()));
                    }
                    MessageLbl.Text = "";
                }
            }
            if (ConfirmReplace1.Visible == true)
            {
                imgb1.ImageUrl = "~/img/show1.png";
                imgb2.ImageUrl = "~/img/show2.png";
                imgb3.ImageUrl = "~/img/show3.png";
                MessageLbl.Text = "";
            }
            if (QA_Ignore.Visible == true)
            {
                DataTable dt = new QAManage().QueryComments();
                QAText.Text = dt.Rows[QADpl.SelectedIndex]["question"].ToString();
            }
        }

        public void OnAnyArticleDelete(string id, int a)
        {
            bool i = false;
            if (a == 1)
                i = new docManage().Delete(id);
            else if (a == 2)
                i = new picNewsManage().Delete(id);
            if (i == true)
                Response.Write("<script lang=javascript>alert('成功！点击刷新按钮以继续！')</script>");
            else Response.Write("<script lang=javascript>alert('失败！点击刷新按钮后重新尝试！')</script>");
        }

        protected void SuperDelete_Click(object sender, EventArgs e)
        {
            int func = 0;
            string id = null;
            if (picnewsdpl.SelectedValue == "" && docid != null)
            {
                func = 1;
                id = docid;
            }
            if (picnewsdpl.SelectedValue != "" && docid == null)
            {
                func = 2;
                id = picnewsdpl.SelectedValue.ToString();
            }
            OnAnyArticleDelete(id, func);
        }
    }
}