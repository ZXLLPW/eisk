using System;
using System.Web.UI.WebControls;
using Eisk.DataAccess;
using Eisk.Helpers;

public partial class Code_Sample_Details_Page : System.Web.UI.Page
{
    #region "Data Operation and Navigation Command Handlers"
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        if (formViewEmployee.CurrentMode == FormViewMode.Insert)
        {
            formViewEmployee.InsertItem(true);
        }
        else
        {
            formViewEmployee.UpdateItem(true);
        }
    }


    protected void ButtonEdit_Click(object sender, EventArgs e)
    {
        formViewEmployee.ChangeMode(FormViewMode.Edit);
    }

    protected void ButtonGoToListPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("listing-page.aspx");
    }

    protected void ButtonGoToPrintPage_Click(object sender, EventArgs e)
    {
        if (formViewEmployee.CurrentMode != FormViewMode.Insert)
        {
            string script = "window.open('print-page.aspx','')";
            if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
            }
        }
    }
    #endregion

    #region "Select handlers"
    protected void OdsEmployeeDetails_Selecting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["employeeId"] = WebManager.ParseItemId(this,formViewEmployee);
        if (formViewEmployee.CurrentMode == FormViewMode.Insert)
            e.Cancel = true;
    }
    #endregion

    #region "Update handlers"

    protected void FormViewEmployee_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        if (!String.IsNullOrEmpty(((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileName))
            e.NewValues["photo"] = ((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileBytes;
        else
            e.NewValues["photo"] = null;
    }

    protected void OdsEmployeeDetails_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {

        //getting the result
        bool result = Convert.ToBoolean(e.ReturnValue, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

        if (result)
        {
            Message = "Update successful.";
            //'We can ignore the line below, if we need to return just after the updation operation
            formViewEmployee.DefaultMode = FormViewMode.Edit;
        }
        else
        {
            e.ExceptionHandled = true;
            Message = "Update not successful. ";
            if (e.Exception != null) Message += e.Exception.Message;
        }
    }

    #endregion

    #region "Insert handlers"

    protected void FormViewEmployee_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (!String.IsNullOrEmpty(((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileName))
        {
            e.Values["photo"] = ((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileBytes;
        }
        else
        {            
            e.Values["photo"] = null;
        }
    }
    
    protected void OdsEmployeeDetails_Inserted(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
    {
        //getting the result
        int result = Convert.ToInt32(e.ReturnValue,System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
        if (result != 0)
        {
            Message = "Insert successful.";
            //We can ignore the line below, if we need to return just after the insertion operation
            WebManager.UpdateItemId(result.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat), formViewEmployee);
        }
        else
        {
            e.ExceptionHandled = true;
            Message = "Insert Not successful. ";
            if (e.Exception != null) Message += e.Exception.Message;
        }
    }

    #endregion

    #region "Populating and binding special controls"

    //customzed data operations over databound controls in form view
    protected void FormViewEmployee_DataBound(object sender, System.EventArgs e)
    {
        TextBox txtFirstName = (TextBox)formViewEmployee.FindControl("txtFirstName");
        TextBox txtLastName = (TextBox)formViewEmployee.FindControl("txtLastName");
        TextBox txtHireDate = (TextBox)formViewEmployee.FindControl("txtHireDate");
        TextBox txtAddress = (TextBox)formViewEmployee.FindControl("txtAddress");
        TextBox txtHomePhone = (TextBox)formViewEmployee.FindControl("txtHomePhone");
        DropDownList ddlCountry = (DropDownList)formViewEmployee.FindControl("ddlCountry");

        //since in read-only mode there is no text box control
        if (formViewEmployee.CurrentMode != FormViewMode.ReadOnly)
        {

            //using data value in form in custom way
            if (formViewEmployee.CurrentMode == FormViewMode.Edit)
            {
                Employee employee = (Employee)formViewEmployee.DataItem;
            }
              
            //populating per-fill data
            if (formViewEmployee.CurrentMode == FormViewMode.Insert)
            {
                txtFirstName.Text = "Ashraful";
                txtLastName.Text = "Alam";
                txtHireDate.Text = DateTime.Now.ToString();
                txtAddress.Text = "One Microsoft Way";
                txtHomePhone.Text = "912200022";
                ddlCountry.Items.FindByText("USA").Selected = true;
            }
        }

        //binding last data operation message
        Label lblMessage = (Label)formViewEmployee.FindControl("lblMessage");
        if (lblMessage != null)
        {
            lblMessage.Text = Message;
        }
    }
    #endregion

    string _message = String.Empty;
    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }

   
}
