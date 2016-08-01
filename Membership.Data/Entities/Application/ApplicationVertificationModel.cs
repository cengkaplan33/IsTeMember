using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Application
{
    [Table("ApplicationVertificationModel")]
    public class ApplicationVertificationModel : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Uygulama Id'si
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        ///     Doğrulama yöntemi Id'si
        /// </summary>
        public int VertificationModelId { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}