using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using HoiioSDK.NET;

namespace HoiioWCFService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CommService : ICommService
    {


        StringBuilder msgCallBack = new StringBuilder();
        string sessionID = "wala";
        string sourceMobile;

        public string GetKeyInput()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

            return msgCallBack.ToString(); ;
        }


      


        public void StartCall()
        {
            msgCallBack.Clear();
            msgCallBack.Append(string.Format("[{0}] Call started ...", DateTime.Now.ToString()));
            sourceMobile = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["sourcemobile"];

            GlobalSettings.Instance.RefreshSettings();

            if (sourceMobile.Length > 0)
            {
                HoiioService service = new HoiioService(GlobalSettings.Instance.AppID, GlobalSettings.Instance.AppToken);
                IVRTransaction res = service.ivrDial(GlobalSettings.Instance.WelcomeMessage, sourceMobile, null, "dial", GlobalSettings.Instance.CallBackURL);


                if (res.success)
                {
                    sessionID = res.session;

                }
                else
                {
                    sessionID = "wala";
                }
            }
            

        }





        public void NotificationHandler()
        {
            msgCallBack.Append ( string.Format ("[{0}] {1}", DateTime.Now.ToString (), WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.OriginalString));

            string thisSession = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["session"];
            msgCallBack.Append(string.Format("[{0}] Session ID = {1} ", DateTime.Now.ToString(), thisSession));

            if (thisSession.Length > 0)
            {
                string tag = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["tag"];
                msgCallBack.Append(string.Format("[{0}] Session ID = {1} Tag = {2} ...", DateTime.Now.ToString(), thisSession, tag));

                if ("dial" == tag)
                {
                    performGather(thisSession);
                    //perform gather
                }

                if ("gather" == tag)
                {
                    string key = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["digits"];

                    msgCallBack.Append(string.Format("[{0}] Session ID = {1} Tag = {2} Key = {3}...", DateTime.Now.ToString(), thisSession, tag, key));

                    if (key.Length > 0)
                    {
                        performTransfer(thisSession,key);
                    }
                    else
                    {
                        performGather(thisSession);
                    }
                   
                }

                
            }


        }

        private void performGather(string session)
        {

            
            msgCallBack.Append(string.Format("[{0}] Gathering user input ...", DateTime.Now.ToString()));
            HoiioService service = new HoiioService(GlobalSettings.Instance.AppID,(GlobalSettings.Instance.AppToken));
            HoiioResponse res = service.ivrGather(session, GlobalSettings.Instance.GatherMessage, 1, 10, 2, "gather", (GlobalSettings.Instance.CallBackURL));
            

            if (res.success)
            {
                msgCallBack.Append(string.Format("[{0}] Gathering user input ... success!", DateTime.Now.ToString()));
                

            }
            else
            {

                msgCallBack.Append(string.Format("[{0}] Gathering user input ... failed! StatusString = {1}", DateTime.Now.ToString(), res.statusString));
               
            }
        }



        private void performTransfer(string session, string digit)
        {
            msgCallBack.Append(string.Format("[{0}] Transfering Call ...key={1}", DateTime.Now.ToString(), digit));
            string transferNo = GlobalSettings.Instance.GetMobileNumber(digit);
            HoiioService service = new HoiioService(GlobalSettings.Instance.AppID, (GlobalSettings.Instance.AppToken));
            HoiioResponse res = service.ivrTransfer(session, GlobalSettings.Instance.TransferMessage, transferNo, null, "transfer", GlobalSettings.Instance.CallBackURL);
           

            if (res.success)
            {
                msgCallBack.Append(string.Format("[{0}] Transfering Call ... success!", DateTime.Now.ToString()));
            }
            else
            {
                msgCallBack.Append(string.Format("[{0}] Transfering Call ... failed! StatusString = {1}", DateTime.Now.ToString(), res.statusString));
               
            }
        }
    }
}
