<%@ Page Title="" Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="temp_pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource2">
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="DeleteEmployee" SelectMethod="GetAllTopAndGeneralEmployees" 
        TypeName="Eisk.DataAccess.Employee">
        <DeleteParameters>
            <asp:Parameter Name="employeeId" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>

