using Ede.Uof.Utility.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class CDS_XML_Lab1 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XElement xe = new XElement("ContactList");

        XElement item01 = new XElement("Contact",
                       new XAttribute("name", "Emma"),
                                  new XAttribute("Phone", "0912345678"));
        XElement item02 = new XElement("Contact",
                       new XAttribute("name", "John"),
                    new XAttribute("Phone", "0923456789"));
        XElement item03 = new XElement("Contact",
            new XAttribute("name", "Mary"),
                    new XAttribute("Phone", "0934567890"));
             
        xe.Add(item01, item02, item03);
        txtXML.Text = xe.ToString();
    }

    protected void btnGetValue_Click(object sender, EventArgs e)
    {
        XElement xe = XElement.Parse(txtXML.Text);  
        var result = xe.Elements("Contact").Where(x => x.Attribute("name").Value == txtID.Text).FirstOrDefault();

        if (result != null)
        {
            txtValue.Text = result.Attribute("Phone").Value;
        }
        else
        {
            txtValue.Text = "查無資料";
        }
    }
}