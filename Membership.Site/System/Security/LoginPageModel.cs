namespace Membership.Site.Model
{
    public class LoginPageModel
    {
        public string ErrorMessage { get; set; }
        public string Username { get; set; }
        public string ReturnURL { get; set; }
        public bool IsUsingProxy { get; set; }
        public bool DisplayWinLogin { get; set; }
    }
}
