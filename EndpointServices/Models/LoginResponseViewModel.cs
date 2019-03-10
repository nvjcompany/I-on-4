namespace EndpointServices.Models
{
    public class LoginResponseViewModel
    {
        public string Token { get; set; }
        public string Message { get; set; }

        public LoginResponseViewModel(string token, string message)
        {
            this.Token = token;
            this.Message = message;
        }
    }
}
