namespace Membership.Business.Model
{
    public class WebUserIp
    {
        public int Id { get; set; }
        public int WebUserId { get; set; }
        public string Ip { get; set; }
    }
}