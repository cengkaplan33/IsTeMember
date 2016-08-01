namespace Membership.Business.Model
{
    public class WebUserIpModel
    {
        public int Id { get; set; }
        public int WebUserId { get; set; }
        public string Ip { get; set; }
    }
}