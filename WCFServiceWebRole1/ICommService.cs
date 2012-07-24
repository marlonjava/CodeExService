using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace HoiioWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommService" in both code and config file together.
    [ServiceContract]
    public interface ICommService
    {
        //Get Operation
        [OperationContract]
        [WebGet(UriTemplate = "")]
        string GetKeyInput();

        //Get Operation
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "")]
        void NotificationHandler();

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "")]
        //void Gather();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "startcall")]
        void StartCall();
    }
}
