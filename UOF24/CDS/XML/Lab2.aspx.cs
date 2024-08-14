using Ede.Uof.Utility.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class CDS_XML_Lab2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XElement formXe = new XElement("Form"
            , new XAttribute("formVersionId",Guid.NewGuid().ToString())
            , new XAttribute("urgentLevel", "2"));

        XElement applicantXe = new XElement("Applicant"
                       , new XAttribute("account", "Tony")
                                  , new XAttribute("groupId", "")
                                  , new XAttribute("jobTitleId", ""));
        XElement commentXe = new XElement("Comment");
        commentXe.Value = "有事";

        XElement formFieldValueXe = new XElement("FormFieldValue");
        XElement noXe = new XElement("FieldItem",
            new XAttribute("fieldId","NO"),
            new XAttribute("fieldValue", "A001"));

        XElement a01Xe = new XElement("FieldItem",
           new XAttribute("fieldId", "A01"),
           new XAttribute("fieldValue", "事假"));

        XElement a02Xe = new XElement("FieldItem",
           new XAttribute("fieldId", "A02"),
           new XAttribute("fieldValue", "2024/08/14"));

        formXe.Add(applicantXe,formFieldValueXe);
        applicantXe.Add(commentXe);

        formFieldValueXe.Add(noXe, a01Xe, a02Xe);

        txtXML.Text = formXe.ToString();

    }

    protected void btnGetValue_Click(object sender, EventArgs e)
    {
        XElement xe = XElement.Parse(txtXML.Text);
        var result = xe.Element("FormFieldValue").Elements("FieldItem").Where(x => x.Attribute("fieldId").Value == txtID.Text).FirstOrDefault();

        if (result != null)
        {
            txtValue.Text = result.Attribute("fieldValue").Value;
        }
        else
        {
            txtValue.Text = "查無資料";
        }
    }
}