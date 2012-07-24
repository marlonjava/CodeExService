﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace HoiioWCFService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("CommService", new WebServiceHostFactory(), typeof(CommService)));
            RouteTable.Routes.Add(new ServiceRoute("SMSService", new WebServiceHostFactory(), typeof(SMSService))); 
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}