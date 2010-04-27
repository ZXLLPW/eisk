using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Eisk.DataAccess;

public partial class misc_sample_multiple_resultset_employees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Tuple<List<Employee>, List<EmployeeWithSupervisorName>> resultSet = Employee.GetAllTopAndGeneralEmployees();
            
            grdTopLevelEmployees.DataSource = resultSet.Item1;
            grdGeneralEmployees.DataSource = resultSet.Item2;

            grdTopLevelEmployees.DataBind();
            grdGeneralEmployees.DataBind();

        }
    }
}