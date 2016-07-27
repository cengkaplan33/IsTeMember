using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.VertificationModel
{
    [Table("VertificationModel")]
    public class VertificationModel : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Yetki doğrulama yöntemi adı
        /// </summary>
        public string VertificationModelName { get; set; }

        /// <summary>
        ///     Açıklama
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}