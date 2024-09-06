<%@ Page Title="" Language="C#" MasterPageFile="~/Master/DialogMasterPage.master" AutoEventWireup="true" CodeFile="SelectSuppliers.aspx.cs" Inherits="CDS_WKF_Fields_SelectSuppliers" %>
<%@ Register Assembly="Ede.Uof.Utility.Component.Grid" Namespace="Ede.Uof.Utility.Component" TagPrefix="Ede" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="關鍵字"></asp:Label>
    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" />
 
    <Ede:Grid ID="grid" runat="server" AutoGenerateColumns="false" AutoGenerateCheckBoxColumn="false"
        AllowPaging="true" OnPageIndexChanging="grid_PageIndexChanging"  OnRowCommand="grid_RowCommand"
        >
        <Columns>
            <asp:TemplateField HeaderText="公司名稱">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSelect"
                        CommandName="lnkSelect" CommandArgument='<%# Eval("SupplierID") %>'
                        runat="server" Text='<%# Eval("CompanyName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="公司名稱" DataField="CompanyName" />
             <asp:BoundField HeaderText="聯絡人" DataField="ContactName" />
             <asp:BoundField HeaderText="職稱" DataField="contactTitle" />
             <asp:BoundField HeaderText="地址" DataField="Address" />
             <asp:BoundField HeaderText="所在城市" DataField="CompanyName" />
        </Columns>
    </Ede:Grid>
</asp:Content>

