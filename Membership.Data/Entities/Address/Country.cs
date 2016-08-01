using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Address
{
    [Table("Country")]
    public class Country : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Ülke Iso kodu
        /// </summary>
        public string CountryIsoCode { get; set; }

        /// <summary>
        ///     Ülke kodu
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///     Ülke adı
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}