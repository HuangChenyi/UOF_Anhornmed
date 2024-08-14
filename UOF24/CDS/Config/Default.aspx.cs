using Ede.Uof.Utility.Configuration;
using Ede.Uof.Utility.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CDS_Config_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Setting setting = new Setting();
      
           txtNasFolder.Text = setting["Anhornmed_NasFolder"];
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Setting setting = new Setting();

        setting["Anhornmed_NasFolder"]= txtNasFolder.Text;

        ScriptManager.RegisterStartupScript(this, this.GetType(), "js", $"alert('{lblSucc.Text}');", true);
    }
}