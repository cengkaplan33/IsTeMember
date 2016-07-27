using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountSecurityCode")]
    public class AccountSecurityCode : DomainBase
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
        ///     Güvenlik/Pin kodu
        /// </summary>
        public string SecurityCode { get; set; }
    }
}