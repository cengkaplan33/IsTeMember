using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountSocialUser")]
    public class AccountSocialUser : DomainBase
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
        ///     Sosyal uygulama Id'si
        /// </summary>
        public int SocialAppTypeId { get; set; }

        /// <summary>
        ///     Kullanıcı sosyal uygulama kimlik Id'si
        /// </summary>
        public string SocialAppIdentityNo { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}