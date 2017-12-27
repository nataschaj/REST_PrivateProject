using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModelLibrary;

namespace REST_PrivateProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        #region GET
        [OperationContract] //betyder at en metode definere operation/funktion. Kun metoder med en operationcontract vises i client
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "catches")
            ]
        List<Catch> GetCatches();
        #endregion

        #region GET BY ID
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catch/{id}")
        ]
        Catch GetOneCatch(String id);
        #endregion

        #region POST
        [OperationContract]
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                //ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches")
        ]
        void AddCatch(Catch newCatch);
        #endregion

        #region DELETE
        [OperationContract]
        [WebInvoke(
                Method = "DELETE",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches?id={id}")
        ]
        Catch DeleteCatch(int id);
        #endregion

        #region PUT
        [OperationContract]
        [WebInvoke(
                Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches")
        ]
        Catch UpdateCatch(Catch myCatch);
        #endregion

    }


}
