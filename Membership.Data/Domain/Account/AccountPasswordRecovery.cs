using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountPasswordRecovery")]
    public class AccountPasswordRecovery : DomainBase
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
        ///     Kullanıcı email'i
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Benzersiz işlem Id'si
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }       
    }
}