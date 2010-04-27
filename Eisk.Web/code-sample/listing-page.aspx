<%@ Page Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true"
    CodeFile="listing-page.aspx.cs" Inherits="Code_Sample_Listing_Page" Title="Employee Listing Page" 
     MetaKeywords="ASP.NET,Employees,HR,Management" MetaDescription="In this page you will be able to view the list of all employess. Click on the appropriate buttons to view, insert or update an employee."
    %>

<%@ Register Assembly="Eisk.DataAccess" Namespace="Eisk.DataAccess" TagPrefix="CustomControl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="Server">
    <table id="tblOuter" class="contentcontainerTBL" summary="table1 summary info" width="100%">
        <caption>
        </caption>
        <thead>
            <tr>
                <th class="invisible" title="Outer table Header">
                </th>
            </tr>
        </thead>
        <tr>
            <td>
                <br />
                <p class="tblHeaderTitleSize">
                    Employees
                </p>
                <p>
                    In this page you will be able to view the list of all employess. Click on the appropriate
                    buttons to view, insert or update an employee.
                </p>
            </td>
        </tr>
        <tr>
            <td>
                Employee:
                <asp:DropDownList ID="dropDownListEmployee" runat="server" AppendDataBoundItems="true"
                    DataSourceID="odsEmployeeList" DataTextField="FirstName" DataValueField="EmployeeId"
                    EnableViewState="false">
                    <asp:ListItem Text="All" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsEmployeeList" runat="server" TypeName="Eisk.DataAccess.Employee"
                    EnableViewState="true" SelectMethod="GetAllEmployees" />
                <asp:Button runat="server" Text="Filter" ID="buttonFilter" CssClass="button-search"
                    AccessKey="f" Width="75px" OnClick="buttonFilter_Click" />
            </td>
        </tr>
        <tr class="spacerrowTBL">
            <td>
                <asp:Label EnableViewState="false" runat="server" ID="labelMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tblInner" class="uirowcontainerTBL" summary="table2 summary">
                    <caption>
                    </caption>
                    <thead>
                        <tr>
                            <th class="invisible" title="inner table Header">
                            </th>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            <asp:GridView ID="gridViewEmployees" runat="server" SkinID="GridView" DataSourceID="odsEmployeeDetails"
                                DataKeyNames="EmployeeId" AllowPaging="True" BorderWidth="1px" BorderStyle="Solid"
                                OnRowCommand="GridViewEmployees_RowCommand" OnRowDataBound="GridViewEmployees_RowDataBound"
                                UseAccessibleHeader="False" AllowSorting="True">
                                <Columns>
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="True" SortExpression="LastName" />
                                    <asp:BoundField DataField="Country" HeaderText="Country" ReadOnly="True" SortExpression="Country" />
                                    <asp:TemplateField>
                                        <ItemStyle Width="50px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnbView" AlternateText="view" ImageUrl="~/image/view_icon.gif"
                                                runat="server" CommandName="cmdView" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            View
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="50px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnbEdit" AlternateText="edit" ImageUrl="~/image/edit_icon.gif"
                                                runat="server" CommandName="cmdEdit" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="50px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnbDelete" AlternateText="abc" ImageUrl="~/image/ico_delete2.gif"
                                                runat="server" CommandName="cmdDelete" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="50px" />
                                        <ItemTemplate>
                                            &nbsp;<asp:CheckBox runat="server" ID="chkEmployeeSelector" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            &nbsp;<asp:CheckBox runat="server" ID="chkSelectAll" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="padding-left: 140px">
                <asp:Button ID="buttonAdd" AccessKey="a" runat="server" Text="Add Employee" SkinID="AspButton"
                    OnClientClick="enableField" OnClick="ButtonAdd_Click" />
                <asp:Button AccessKey="d" OnClientClick="return confirm('Are you sure you want to delete all items?');"
                    runat="server" ID="buttonDeleteSelected" Text="Delete Selected" SkinID="AspButton"
                    OnClick="ButtonDeleteSelected_Click" />
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsEmployeeDetails" runat="server" TypeName="Eisk.DataAccess.Employee"
        DeleteMethod="DeleteEmployee" SelectMethod="GetEmployeesByReportsToPaged" SelectCountMethod="GetEmployeesByReportsToPagedCount"
        SortParameterName="orderby" MaximumRowsParameterName="maximumRows" StartRowIndexParameterName="startRowIndex"
        EnablePaging="True" OnDeleted="odsEmployeeDetails_Deleted">
        <SelectParameters>
            <asp:ControlParameter Name="reportsTo" ControlID="dropDownListEmployee" />
            <asp:Parameter Name="orderBy" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:ControlParameter ControlID="gridViewEmployees" Name="employeeId" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
