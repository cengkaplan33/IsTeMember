using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Application
{
    [Table("Application")]
    public class Application : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Benzersiz uygulama kodu
        /// </summary>
        public string ApplicationCode { get; set; }

        /// <summary>
        ///     Uygulama adı
        /// </summary>
        public string ApplicationName { get; set; }

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