<%@ Page Title="" Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true" CodeFile="multiple-resultset-employees.aspx.cs" Inherits="misc_sample_multiple_resultset_employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" Runat="Server">
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
                    Employees with Supervisors
                </p>
                <p>
                    In this page you will be able to view the list of all employess. Click on the appropriate
                    buttons to view, insert or update an employee.
                </p>
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
                            <asp:GridView ID="grdTopLevelEmployees" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                SkinID="GridView">
                                <Columns>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="grdGeneralEmployees" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                SkinID="GridView">
                                <Columns>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                    <asp:BoundField DataField="SupervisorFirstName" HeaderText="SupervisorFirstName"
                                        SortExpression="SupervisorFirstName" />
                                    <asp:BoundField DataField="SupervisorLastName" HeaderText="SupervisorLastName" SortExpression="SupervisorLastName" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteEmployee"
                                SelectMethod="GetAllTopAndGeneralEmployees" TypeName="Eisk.DataAccess.Employee">
                                <DeleteParameters>
                                    <asp:Parameter Name="employeeId" Type="Int32" />
                                </DeleteParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

