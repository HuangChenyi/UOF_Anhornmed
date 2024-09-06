using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ede.Uof.EIP.Organization.Util;
using Ede.Uof.Utility.Configuration;
using Ede.Uof.Utility.FileCenter.V3;
using Ede.Uof.WKF.ExternalUtility;
using Training.UCO;

namespace Training.Trigger.DemoForm
{
    public class EndFormTrigger : ICallbackTriggerPlugin
    {
        public void Finally()
        {
            //  throw new NotImplementedException();
        }

        public string GetFormResult(ApplyTask applyTask)
        {
            // throw new NotImplementedException();

            //<Form formVersionId="30d33f52-802f-49b3-933e-f93a9c5d61cb">
            //  <FormFieldValue>
            //    <FieldItem fieldId="NO" fieldValue="" realValue="" />
            //    <FieldItem fieldId="A01" fieldValue="xxx" realValue="" fillerName="黃建龍" fillerUserGuid="07a00c72-270e-403e-b9df-20b530ba45e8" fillerAccount="Howard_Huang" fillSiteId="" />
            //    <FieldItem fieldId="A02" fieldValue="3" realValue="" fillerName="黃建龍" fillerUserGuid="07a00c72-270e-403e-b9df-20b530ba45e8" fillerAccount="Howard_Huang" fillSiteId="" />
            //    <FieldItem fieldId="A03" fieldValue="4" realValue="" fillerName="黃建龍" fillerUserGuid="07a00c72-270e-403e-b9df-20b530ba45e8" fillerAccount="Howard_Huang" fillSiteId="" />
            //    <FieldItem fieldId="A04" fieldValue="222" realValue="" fillerName="黃建龍" fillerUserGuid="07a00c72-270e-403e-b9df-20b530ba45e8" fillerAccount="Howard_Huang" fillSiteId="" />
            //  </FormFieldValue>
            //</Form>

            DemoUCO uco = new DemoUCO();
            string docNbr = applyTask.FormNumber;
            string signStatus = applyTask.FormResult.ToString();

            uco.UpdateFormResult(docNbr, signStatus);

            Setting setting = new Setting();
            string folder = setting["Anhornmed_NasFolder"];

            if(applyTask.FormResult== Ede.Uof.WKF.Engine.ApplyResult.Adopt)
            {
                string fileGroupId = applyTask.Task.CurrentDocument.Fields["attach"].FieldValue;
            
                FileGroup fg = FileCenter.GetFileGroup(fileGroupId);
                if (fg != null)
                {
                    foreach (var file in fg)
                    {
                        string fileName = file.Name;

                        Stream s = file.GetLocalFileStream();
                        //Copy To folder
                        using (FileStream fs = new FileStream(folder + fileName, FileMode.Create))
                        {
                            s.CopyTo(fs);
                        }
                    }

                }
                
                string formVersionId = uco.GetUsingFormVersionId("LabForm");
                var applicant = applyTask.Task.Applicant;
                var fields= applyTask.Task.CurrentDocument.Fields;
                XElement formXE = new XElement("Form" , new XAttribute("formVersionId", formVersionId)
                    , new XAttribute("urgentLevel", "2"));

                XElement applicantXE = new XElement("Applicant",
                    new XAttribute("account", applicant.Account),
                    new XAttribute("groupId", ""),
                    new XAttribute("jobTitleId","")) ;

                XElement commentXe =new XElement("Comment", "This is a test");


                XElement formFieldValueXE = new XElement("FormFieldValue");

                XElement noXE = new XElement("FieldItem", new XAttribute("fieldId", "NO"), new XAttribute("fieldValue", ""), new XAttribute("realValue", ""));

                XElement a01XE = new XElement("FieldItem", new XAttribute("fieldId", "A01"), new XAttribute("realValue", ""), 
                    new XAttribute("fillerName", applicant.UserName), 
                    new XAttribute("fillerUserGuid", applicant.UserGUID), 
                    new XAttribute("fillerAccount", applicant.Account),
                    new XAttribute("fillSiteId", ""));

                //<FormChooseInfo taskGuid="a3ffda34-9c5a-4ba2-b040-e17783fb5c6e" />
                XElement formChooseInfoXE = new XElement("FormChooseInfo", new XAttribute("taskGuid", applyTask.Task.TaskId));

                a01XE.Add(formChooseInfoXE);

                //從MAPPING表中找到對應的人  假設找到的是May

                UserUCO userUCO = new UserUCO();
                string userGuid = userUCO.GetGUID("Mary");
                EBUser ebUser = userUCO.GetEBUser(userGuid);

                UserSet userSet = new UserSet();
                UserSetUser userSetUser= new UserSetUser(); 
                userSetUser.USER_GUID = ebUser.UserGUID;

                userSet.Items.Add(userSetUser);

                XElement a02XE = new XElement("FieldItem", new XAttribute("fieldId", "A02"),
                    new XAttribute("fieldValue", $"{ebUser.Name}({ebUser.Account})"), 
                    new XAttribute("realValue", userSet.GetXML()), 
                    new XAttribute("fillerName", applicant.UserName), 
                    new XAttribute("fillerUserGuid", applicant.UserGUID),
                    new XAttribute("fillerAccount", applicant.Account), 
                    new XAttribute("fillSiteId", ""));

                XElement typeXE = new XElement("FieldItem", 
                    new XAttribute("fieldId", "type"),
                    new XAttribute("fieldValue", ""), new XAttribute("realValue", ""));

                XElement itemXE = new XElement("FieldItem", new XAttribute("fieldId", "item"),
           new XAttribute("fieldValue", fields["A01"].FieldValue),
           new XAttribute("realValue", ""),
           new XAttribute("fillerName", applicant.UserName),
           new XAttribute("fillerUserGuid", applicant.UserGUID),
           new XAttribute("fillerAccount", applicant.Account),
           new XAttribute("fillSiteId", ""));

                XElement amountXE = new XElement("FieldItem", new XAttribute("fieldId", "amount"),
new XAttribute("fieldValue", fields["A02"].FieldValue),
new XAttribute("realValue", ""),
new XAttribute("fillerName", applicant.UserName),
new XAttribute("fillerUserGuid", applicant.UserGUID),
new XAttribute("fillerAccount", applicant.Account),
new XAttribute("fillSiteId", ""));


                formXE.Add(applicantXE,formFieldValueXE);

                applicantXE.Add(commentXe);

                formFieldValueXE.Add(noXE, a01XE, a02XE, typeXE, itemXE, amountXE);


                Ede.Uof.WKF.Utility.TaskUtilityUCO taskUtilityUCO = new Ede.Uof.WKF.Utility.TaskUtilityUCO();   

               var result= taskUtilityUCO.WebService_CreateTask(formXE.ToString());

                XElement resultXE = XElement.Parse(result);

                if(resultXE.Element("Status").Value == "1")
                {

                }
                else
                {              
                    throw new Exception(resultXE.Element("Exception").Element("Message").Value);
                }
            }

            return "";
        }

        public void OnError(Exception errorException)
        {
            //  throw new NotImplementedException();
        }
    }
}
