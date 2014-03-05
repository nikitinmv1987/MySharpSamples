using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTfull_WCF_Service
{
  [ServiceContract]  
  public interface IRestServiceImpl
  {
    [OperationContract]
    [WebInvoke(Method = "GET",
      ResponseFormat = WebMessageFormat.Xml,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "xml/{id}")]
    string XMLData(string id);

    [OperationContract]
    [WebInvoke(Method = "GET",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "json/{id}")]
    string JSONData(string id);
  }
}
