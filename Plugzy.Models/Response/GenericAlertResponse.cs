using Newtonsoft.Json;

namespace Plugzy.Models.Response
{
    public class GenericAlertResponse
    {
        public GenericAlertResponse()
        {
        }

        public GenericAlertResponse(string messageCode, AlertResponseType messageType, GenericAlertData data)
        {
            MessageCode = messageCode;
            MessageTypeValue = messageType;
            Data = data;
        }

        public string MessageCode { get; set; }
        public AlertResponseType MessageTypeValue { get; set; }
        public string? MessageType => MessageTypeValue.ToString();
        public GenericAlertData Data { get; set; }
        public string DataStr => JsonConvert.SerializeObject(Data, new JsonSerializerSettings
        {
            ContractResolver = null//new CamelCasePropertyNamesContractResolver()
        });
        public string SerializeResponse() => JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            ContractResolver = null//new CamelCasePropertyNamesContractResolver()
        });



    }
    public class GenericAlertData
    {
        public GenericAlertData()
        {
        }

        public GenericAlertData(string type, string? title, string? detail, string? buttontext, string? link, bool? isDimissible = null, int? duration = null, AlertType? genericAlertType = null)
        {
            Type = type;
            Title = title;
            PrimaryButtonText = buttontext;
            Detail = detail;
            IsDismissible = isDimissible ?? false;
            ButtonDeepLinkPath = link;
            Duration = duration;
            GenericAlertTypeValue = genericAlertType ?? AlertType.verticalSingle;
        }

        public string? Type { get; set; }
        public AlertType? GenericAlertTypeValue { get; set; }
        public string? GenericAlertType => GenericAlertTypeValue?.ToString();
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public string? Custom { get; set; }
        public string? Color { get; set; }
        public string? PrimaryButtonText { get; set; }
        public string? SecondaryButtonText { get; set; }
        public string? ButtonDeepLinkPath { get; set; }
        public string? SecondaryButtonDeepLinkPath { get; set; }
        public bool? IsDismissible { get; set; }
        public int? Duration { get; set; }
    }


    public enum AlertResponseType
    {
        toast = 1,
        modal,
        alert,
        toastWTime
    }
    public enum AlertType
    {
        verticalSingle = 1,
        vertical,
        verticalReverse,
        horizontal,
        horizontalCancel,
    }
}
