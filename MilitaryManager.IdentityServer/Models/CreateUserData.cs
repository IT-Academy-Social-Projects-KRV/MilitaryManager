namespace MilitaryManager.IdentityServer.Models
{
    public class CreateUserData
    {
        public string Username { get; set; }
        public string Password { get; set; }    
        public string Role { get; set; }
    }
}
