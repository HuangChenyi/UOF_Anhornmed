<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuppliersInfo.ascx.cs" Inherits="WKF_OptionalFields_SuppliersInfo" %>
<%@ Reference Control="~/WKF/FormManagement/VersionFieldUserControl/VersionFieldUC.ascx" %>
<%@ Register Assembly="Ede.Uof.Utility.Component.Grid" Namespace="Ede.Uof.Utility.Component" TagPrefix="Ede" %>
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

<Ede:Grid ID="grid" runat="server" AutoGenerateColumns="false" AutoGenerateCheckBoxColumn="false"></Ede:Grid>


<asp:Label ID="lblHasNoAuthority" runat="server" Text="無填寫權限" ForeColor="Red" Visible="False" meta:resourcekey="lblHasNoAuthorityResource1"></asp:Label>
<asp:Label ID="lblToolTipMsg" runat="server" Text="不允許修改(唯讀)" Visible="False" meta:resourcekey="lblToolTipMsgResource1"></asp:Label>
<asp:Label ID="lblModifier" runat="server" Visible="False" meta:resourcekey="lblModifierResource1"></asp:Label>
<asp:Label ID="lblMsgSigner" runat="server" Text="填寫者" Visible="False" meta:resourcekey="lblMsgSignerResource1"></asp:Label>
<asp:Label ID="lblAuthorityMsg" runat="server" Text="具填寫權限人員" Visible="False" meta:resourcekey="lblAuthorityMsgResource1"></asp:Label>