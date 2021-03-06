<%@ Application Language="C#" %>

<script runat="server">

    protected void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        
    }
    
    protected void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    protected void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        Eisk.Helpers.ErrorLogger.ReportLastError();
    }

    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {

        if (HttpContext.Current.User != null)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                if (HttpContext.Current.User.Identity.AuthenticationType != "Forms")
                    throw new InvalidOperationException("Only forms authentication is supported, not " +
                        HttpContext.Current.User.Identity.AuthenticationType);

                System.Security.Principal.IIdentity userId = HttpContext.Current.User.Identity;

                //if role info is already NOT loaded into cache, put the role info in cache
                if (System.Web.HttpContext.Current.Cache[userId.Name] == null)
                {
                    string[] roles;

                    if (userId.Name == "admin1")
                        roles = new string[1] { "admin" };//this info will be generally collected from database
                    else if (userId.Name == "member1")
                        roles = new string[1] { "member" };//this info will be generally collected from database
                    else
                        roles = new string[1] { "public" };//this info will be generally collected from database                   

                    //1 hour sliding expiring time. Adding the roles in chache. This will be used in Application_AuthenticateRequest event located in Global.ascx.cs file to attach user Principal object.
                    System.Web.HttpContext.Current.Cache.Add(userId.Name, roles, null, DateTime.MaxValue, TimeSpan.FromHours(1), System.Web.Caching.CacheItemPriority.BelowNormal, null);
                }

                //now assign the user role in the current security context
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(userId, (string[])System.Web.HttpContext.Current.Cache[userId.Name]);
            }
        }

    }


    protected void Session_Start(object sender, EventArgs e) 
    {
        if (!Eisk.DataAccessHelpers.ConnectionStringManager.IsConnectionStringOk())
            Response.Redirect("~/public/install.aspx");

    }

    protected void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
