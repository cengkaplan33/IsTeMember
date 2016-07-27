using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountPasswordChange")]
    public class AccountPasswordChange : DomainBase
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
        ///     Eski şifresi
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        ///     Yeni şifresi
        /// </summary>
        public string NewPassword { get; set; }
    }
}