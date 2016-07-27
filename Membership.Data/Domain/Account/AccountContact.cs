using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountContact")]
    public class AccountContact : DomainBase
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
        ///     Kontak başlığı
        /// </summary>
        public string ContactTitle { get; set; }

        /// <summary>
        ///     Kontak adı
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        ///     Telefon
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     Dahili numara
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        ///     Faks
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        ///     Gsm
        /// </summary>
        public string Gsm { get; set; }

        /// <summary>
        ///     Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Web site
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}