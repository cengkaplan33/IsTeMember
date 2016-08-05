namespace Membership.Business.Model
{
    public class Directory
    {
        public int? Id { get; set; }
        public string DirectoryCode { get; set; }
        public string DirectoryName { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public Application Application { get; set; }
    }
}