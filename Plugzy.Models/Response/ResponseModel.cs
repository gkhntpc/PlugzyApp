namespace Plugzy.Models.Response
{
    public class ResponseModel
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public GenericAlertResponse? GenericAlertResponse { get; set; }
    }
}