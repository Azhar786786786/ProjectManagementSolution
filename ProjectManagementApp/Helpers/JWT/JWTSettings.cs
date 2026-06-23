namespace ProjectManagementApp.Helpers.JWT
{
    public class JWTSettings
    {
        public string SecretKey { get; set; } = String.Empty;
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public int ExpiryMinutes { get; set; }
    }
}
