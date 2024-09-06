<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuppliersInfo.ascx.cs" Inherits="WKF_OptionalFields_SuppliersInfo" %>
<%@ Reference Control="~/WKF/FormManagement/VersionFieldUserControl/VersionFieldUC.ascx" %>
<%@ Register Assembly="Ede.Uof.Utility.Component.Grid" Namespace="Ede.Uof.Utility.Component" TagPrefix="Ede" %>


<script>

    function CheckData(source, arguments) {

        var item = $('#<%=txtData.ClientID%>').val();





        var data = [item];
        var result = $uof.pageMethod.syncUc("CDS/WKF_Fields/SuppliersInfo.ascx", "CheckData1", data);
       

        if (result == "Alert") {
            //alert('有重覆唷!');

            if (confirm('有重覆唷!要繼續送出嗎?')) {
                arguments.IsValid = true;
                return;
            }
            else {
                arguments.IsValid = false;
                return;
            }

        }
        else
        {
            arguments.IsValid = true;
            return;
        }

        
    }

</script>

<table class="PopTable" style="width:600px">
    <tr>
        <td> <asp:Label ID="Label1" runat="server" Text="供應商名稱"></asp:Label></td>
       
        <td><asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnSelect" runat="server" Text="選擇供應商" 
                OnClick="btnSelect_Click"
                CausesValidation="false" />
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="聯絡人"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblContactName" runat="server" Text=""></asp:Label>

        </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="職稱"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>

        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="地址"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>

        </td>
    </tr>
</table>
<asp:TextBox ID="txtData" runat="server"></asp:TextBox>

<asp:CustomValidator ID="CustomValidator1" runat="server" 
    Display="Dynamic" ClientValidationFunction="CheckData"
    ErrorMessage=""></asp:CustomValidator>


<asp:Label ID="lblHasNoAuthority" runat="server" Text="無填寫權限" ForeColor="Red" Visible="False" meta:resourcekey="lblHasNoAuthorityResource1"></asp:Label>
<asp:Label ID="lblToolTipMsg" runat="server" Text="不允許修改(唯讀)" Visible="False" meta:resourcekey="lblToolTipMsgResource1"></asp:Label>
<asp:Label ID="lblModifier" runat="server" Visible="False" meta:resourcekey="lblModifierResource1"></asp:Label>
<asp:Label ID="lblMsgSigner" runat="server" Text="填寫者" Visible="False" meta:resourcekey="lblMsgSignerResource1"></asp:Label>
<asp:Label ID="lblAuthorityMsg" runat="server" Text="具填寫權限人員" Visible="False" meta:resourcekey="lblAuthorityMsgResource1"></asp:Label>