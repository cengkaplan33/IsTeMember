using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Role
{
    [Table("RoleVertificationModel")]
    public class RoleVertificationModel : DomainBase
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
        ///     Yetki doğrulama yöntemi Id’si
        /// </summary>
        public int VertificationModelId { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}