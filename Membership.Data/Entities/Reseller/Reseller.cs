using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Reseller
{
    [Table("Reseller")]
    public class Reseller : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Uygulama Id'si
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        ///     Benzersiz bayi kodu
        /// </summary>
        public string ResellerCode { get; set; }

        /// <summary>
        ///     Bayi tipi Id'si
        /// </summary>
        public int ResellerTypeId { get; set; }

        /// <summary>
        ///     Bayi adı
        /// </summary>
        public string ResellerName { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}