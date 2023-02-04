namespace Voxed.WebApp.Models
{
    public class RegisterResponse
    {
        public bool Status { get; set; }
        public string Token { get; set; }
        public string MaxAge { get; set; }
        public string Swal { get; set; }
    }
}
