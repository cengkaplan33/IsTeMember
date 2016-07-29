namespace Membership.Business.Model
{
    public class WebUser
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string DisplayName;
        public string PasswordHash;
        public string PasswordSalt;
        public string Password;
        public string Email;
    }
}