namespace AspNetGoogleAuth.Models
{
    public class GoogleAuthenticatorViewModel
    {
        public string Code { get; set; }
        public string BarcodeUrl { get; set; }
        public string SecretKey { get; set; }
    }
}