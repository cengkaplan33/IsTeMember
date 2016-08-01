using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Security
{
    [Table("ApiUserIp")]
    public class ApiUserIp : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     ApiUser Id'si
        /// </summary>
        public int ApiUserId { get; set; }

        /// <summary>
        ///     ApiUser Ip'si
        /// </summary>
        public string Ip { get; set; }
    }
}