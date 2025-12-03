using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.IO;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImageVerifierService" in both code and config file together.
    [ServiceContract]
    public interface IImageVerifierService
    {
        [OperationContract]
        [WebGet(UriTemplate = "string", ResponseFormat = WebMessageFormat.Xml)]
        string GetVerifierString();

        [OperationContract]
        [WebGet(UriTemplate = "image?text={text}")]
        Stream GetImage(string text);
    }
}
