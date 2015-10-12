using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Request.QueryString["path"];
        string filePath = Server.MapPath("~") + @"\" + path;
        File.Delete(filePath.ToString());
        string directoryPath = filePath.Substring(0,filePath.Length-4) + ".files";
        foreach (string file in Directory.GetFiles(directoryPath))
        {
            File.Delete(file);
        }
        Directory.Delete(directoryPath);
    }
}