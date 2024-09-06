using Ede.Uof.EIP.Organization.Util;
using Ede.Uof.Utility.Page;
using Ede.Uof.Utility.Page.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.UCO;

public partial class CDS_WKF_Fields_SelectSuppliers : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {




        ((Master_DialogMasterPage)this.Master).Button1Text = "";

        ((Master_DialogMasterPage)this.Master).Button2Text = "";

        if(!IsPostBack)
        {
            BindGrid();
        }    
    }

    private void BindGrid()
    {
        DemoUCO uco = new DemoUCO();
        DataTable dt = uco.GetSuppilers(txtKeyword.Text);

        grid.DataSource = dt;
        grid.DataBind();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "lnkSelect")
        {
            Dialog.SetReturnValue2(e.CommandArgument.ToString());
            Dialog.Close(this);
        }
  
    }
}