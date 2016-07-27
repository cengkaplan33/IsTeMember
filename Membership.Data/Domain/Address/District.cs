using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Address
{
    [Table("District")]
    public class District : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Şehir Id'si
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        ///     Semt kodu
        /// </summary>
        public string DistrictCode { get; set; }

        /// <summary>
        ///     Semt adı
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}