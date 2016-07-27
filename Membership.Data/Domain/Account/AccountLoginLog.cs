using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountLoginLog")]
    public class AccountLoginLog : DomainBase
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
        ///     Ip adresi
        /// </summary>
        public string Ip { get; set; }
    }
}