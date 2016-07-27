using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Role
{
    [Table("RoleRight")]
    public class RoleRight : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Role Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        ///     Yetki Id
        /// </summary>
        public int RightId { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}