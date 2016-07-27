using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Web
{
    [Table("WebUserIp")]
    public class WebUserIp : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     WebUser Id'si
        /// </summary>
        public int WebUserId { get; set; }

        /// <summary>
        ///     WebUser Ip'si
        /// </summary>
        public string Ip { get; set; }
    }
}