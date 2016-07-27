using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountAddress")]
    public class AccountAddress : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Kullanıcı Id'si
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        ///     Adres kodu
        /// </summary>
        public string AddressCode { get; set; }

        /// <summary>
        ///     Adres tipi
        /// </summary>
        public int AddressType { get; set; }

        /// <summary>
        ///     Adres başlığı
        /// </summary>
        public string AddressTitle { get; set; }

        /// <summary>
        ///     Ülke Id'si
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        ///     Şehir Id'si
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        ///     Semt Id'si
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        ///     Ülke Iso kodu
        /// </summary>
        public string CountryIsoCode { get; set; }

        /// <summary>
        ///     Şehir Iso kodu
        /// </summary>
        public string CityIsoCode { get; set; }

        /// <summary>
        ///     Adres
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Zip kodu
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        ///     Vergi dairesi
        /// </summary>
        public string TaxOffice { get; set; }

        /// <summary>
        ///     Vergi numarası
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        ///     Firma adı
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}