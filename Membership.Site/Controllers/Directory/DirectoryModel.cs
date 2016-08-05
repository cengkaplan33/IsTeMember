using System;

namespace Membership.Site.Model
{
    public class DirectoryModel
    {
        public int Id { get; set; }
        public string DirectoryCode { get; set; }
        public string DirectoryName { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public ApplicationModel Application { get; set; }
    }
}