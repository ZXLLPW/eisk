using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Eisk.DataAccessHelpers;

public partial class Master_Default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtGenerateTestData_Click(object sender, EventArgs e)
    {
        SqlScriptUtility.RunScript(Server.MapPath("~") + @".\..\Eisk.Database\Basic Scripts\Data\Clean-Data.sql");
        SqlScriptUtility.RunScript(Server.MapPath("~") + @".\..\Eisk.Database\Basic Scripts\Data\Create-Data.sql");
        lblMessage.Text = "Test Data Generated.";
    }
}
