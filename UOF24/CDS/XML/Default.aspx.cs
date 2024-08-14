using Ede.Uof.Utility.Page.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
public partial class CDS_XML_Default : Ede.Uof.Utility.Page.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SupplierData supplierData = new SupplierData();
        supplierData.SU01100 = "SU01100";
        supplierData.SU01040 = "SU01040";
        txtXML.Text= JsonConvert.SerializeObject(supplierData);
        return;
        XElement xe = new XElement("FieldValue");

        XElement item01 = new XElement("Item",
            new XAttribute("id","A01"),
            new XAttribute("value", "V01"));
        XElement item02 = new XElement("Item",
          new XAttribute("id", "A02"),
          new XAttribute("value", "V02"),"InnerText");
       

        XElement item03 = new XElement("Item",
          new XAttribute("id", "A03"),
          new XAttribute("value", "V<0>3"));

        xe.Add(item01, item02, item03);
 
        txtXML.Text = xe.ToString();
        return;
        //<FieldValue>
        //  <Item id='A01' value='V01' />
        //  <Item id='A02' value='V02' >InnerText</Item>
        //  <Item id='A03' value='V03' />
        //<FieldValue>

        XmlDocument xmlDoc = new XmlDocument();

        //<FieldValue/>
        XmlElement fieldValueElement = xmlDoc.CreateElement("FieldValue");
        
        //  <Item id='A01' value='V01' ></Iteem>        //
        XmlElement item01Element = xmlDoc.CreateElement("Item");
        item01Element.SetAttribute("id" , "A01");
        item01Element.SetAttribute("value", "V01");

        //  <Item id='A02' value='V02' >InnerText</Iteem>        //
        XmlElement item02Element = xmlDoc.CreateElement("Item");
        item02Element.SetAttribute("id", "A02");
        item02Element.SetAttribute("value", "V02");
        item02Element.InnerText = "InnerTextxxxxx";

        //  <Item id='A03' value='V03' ></Iteem>        //
        XmlElement item03Element = xmlDoc.CreateElement("Item");
        item03Element.SetAttribute("id", "A03");
        item03Element.SetAttribute("value", "V<0>3");

        fieldValueElement.AppendChild(item01Element);
        fieldValueElement.AppendChild(item02Element);
        fieldValueElement.AppendChild(item03Element);

        xmlDoc.AppendChild(fieldValueElement);

        txtXML.Text = xmlDoc.OuterXml;



    }
    protected void btnGetValue_Click(object sender, EventArgs e)
    {

        XElement xe = XElement.Parse(txtXML.Text);

        txtValue.Text = xe.Elements("Item").
            Where(x => x.Attribute("id").Value == txtID.Text)
            .FirstOrDefault().Attribute("value").Value;

        return;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(txtXML.Text);

        //<FieldValue>
        //  <Item id='A01' value='V01' />
        //  <Item id='A02' value='V02' >InnerText</Item>
        //  <Item id='A03' value='V03' />
        //<FieldValue>

        txtValue.Text = xmlDoc.SelectSingleNode(string.Format
            ("./FieldValue/Item[@id='{0}']", txtID.Text)).
            Attributes["value"].Value;
    }
}