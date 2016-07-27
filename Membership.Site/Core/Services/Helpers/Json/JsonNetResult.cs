using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Membership.Site.Services
{
    public class JsonNetResult : ActionResult
    {
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public object Data { get; set; }
        public JsonSerializerSettings SerializerSettings { get; set; }
        public Formatting Formatting { get; set; }

        public JsonNetResult(object data)
        {
            JsonSerializerSettings Default;
            Default = new JsonSerializerSettings();
            Default.NullValueHandling = NullValueHandling.Ignore;
            Default.MissingMemberHandling = MissingMemberHandling.Ignore;
            Default.TypeNameHandling = TypeNameHandling.None;
            Default.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            Default.PreserveReferencesHandling = PreserveReferencesHandling.None;
            Data = data;

            SerializerSettings = Default;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting };
                JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }
}