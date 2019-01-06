namespace Resturant.Models
{
    public class UserDetailCredentials
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string grant_type { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }  
        public string token_type { get; set; }
        public string Role { get; set; }
    }
}
