using System;

namespace Membership.Site.Model
{
    public class WebUserModel
    {
        public int? Id { get; set; }
        public int ApplicationId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}