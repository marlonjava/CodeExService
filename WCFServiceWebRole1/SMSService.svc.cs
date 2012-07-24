using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

namespace HoiioWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SMSService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SMSService : ISMSService
    {
        StringBuilder msgCallBack = new StringBuilder();

        public void NotificationHandler()
        {
            msgCallBack.Clear();
            msgCallBack.Append(string.Format("[{0}] {1}", DateTime.Now.ToString(), WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.OriginalString));

            string msg = "";
            string fromNo = "";

            msg = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["msg"];
            fromNo = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["from"];

            if (msg.ToUpper().Trim() == "CALLME")
            {
                //Dictionary<String, String> data = new Dictionary<string,string> ();
                //data.Add("sourcemobile", fromNo);

                //HoiioSDK.NET.HttpService.HttpPostOrig("http://codex2012.cloudapp.net/CommService/startcall?sourcemobile=" + fromNo, data);

                List<String> paramName = new List<string>();
                List<String> paramValue = new List<string>();

                paramName.Add("sourcemobile");
                paramValue.Add(fromNo.Replace("%2B", ""));




                String result = HoiioSDK.NET.HttpService.HttpPostOrig("http://codex2012.cloudapp.net/CommService/startcall?sourcemobile=" + fromNo.Replace("%2B", ""), paramName.ToArray(), paramValue.ToArray());

            }

        }

        public string GetNotificationMessage()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
            return msgCallBack.ToString();
        }
    }
}
