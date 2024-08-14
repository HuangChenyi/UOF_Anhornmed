<%@ Page Title="" Language="C#" MasterPageFile="~/Master/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CDS_Config_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="PopTable">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Nas存放路徑"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNasFolder" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>

    </table>
    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
    <asp:Label ID="lblSucc" runat="server" Text="儲存成功!" Visible="false"></asp:Label>
</asp:Content>

