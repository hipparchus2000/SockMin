using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Net.WebSockets;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.ServiceModel.WebSockets;
using Microsoft.Web.WebSockets;

namespace SockMin.Controllers
{
    [RoutePrefix("SockMin")]
    public class SockMinController : ApiController
    {
        [HttpGet]
        [Route("{resource}/{itemName}")]
        public IHttpActionResult Get(string resource, string itemName)
        {

            switch (resource)
            {
                case "Views":
                    var html = Helpers.FileHelpers.getResourceAsString(resource, itemName+".html");
                    var htmlResult = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(html, Encoding.UTF8, "text/html")
                    };
                    var htmlResponse = ResponseMessage(htmlResult);
                    return htmlResponse;
                    
                case "Styles":
                    var css = Helpers.FileHelpers.getResourceAsString(resource, itemName+".css");
                    var cssResult = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(css, Encoding.UTF8, "text/css")
                    };
                    var cssResponse = ResponseMessage(cssResult);
                    return cssResponse;
                    
                case "JsControllers":
                    var js = Helpers.FileHelpers.getResourceAsString(resource, itemName+".js");
                    var jsResult = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(js, Encoding.UTF8, "text/javascript")
                    };
                    var jsResponse = ResponseMessage(jsResult);
                    return jsResponse;

                case "Zips":
                    var zip = Helpers.FileHelpers.getResourceAsString(resource, itemName+".zip");
                    var zipResult = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(zip, Encoding.UTF8, "application/zip")
                    };
                    var zipResponse = ResponseMessage(zipResult);
                    return zipResponse;

                default:
                    return InternalServerError();
            }
        }




    //    [HttpGet]
    //    [Route("ws")]
    //    public HttpResponseMessage Get(string username)
    //    {
    //        HttpContext.Current.AcceptWebSocketRequest(new SockMinWebSocketHandler(username));
    //        return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
    //    }


    //class SockMinWebSocketHandler : WebSocketHandler
    //    {
    //       private static WebSocketCollection _clients = new WebSocketCollection();
    //       private Guid _connection;
    //       private string _username;
    
    //       public SockMinWebSocketHandler(string username)
    //       {
    //           _username = username;
    //       }
    
    //       public override void OnOpen()
    //       {
    //           _clients.Add(this);
    //       }
    
    //       public override void OnMessage(string message)
    //       {
    //           _clients.Broadcast(_username+" "+ message);
    //              // route message to client
    //       }
    //    }

    }
}
