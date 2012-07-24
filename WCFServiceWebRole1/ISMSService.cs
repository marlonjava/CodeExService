using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace HoiioWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISMSService" in both code and config file together.
    [ServiceContract]
    public interface ISMSService
    {

        //Get Operation
        [OperationContract]
        [WebGet(UriTemplate = "")]
        string GetNotificationMessage();

        //Put Operation
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "")]
        void NotificationHandler();
    }
}
