using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Right
{
    [Table("RightVertificationModel")]
    public class RightVertificationModel : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Yetki Id
        /// </summary>
        public int RightId { get; set; }

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