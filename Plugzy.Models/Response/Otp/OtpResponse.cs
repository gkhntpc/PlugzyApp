namespace Plugzy.Models.Response.Otp;

public class OtpResponse 
{
    public int Seconds { get; set; }
    public bool Confirm { get; set; }
    public int Code { get; set; }
}
