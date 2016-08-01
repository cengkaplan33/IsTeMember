namespace Membership.Business.Model
{
    public class WebUserModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string DisplayName;
        public string Email;
    }
}