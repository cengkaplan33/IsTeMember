using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Address
{
    [Table("City")]
    public class City : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Şehir Iso kodu
        /// </summary>
        public string CityIsoCode { get; set; }

        /// <summary>
        ///     Ülke Id'si
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        ///     Şehir kodu
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        ///     Şehir adı
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}