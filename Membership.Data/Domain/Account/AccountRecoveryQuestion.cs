using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("AccountRecoveryQuestion")]
    public class AccountRecoveryQuestion : DomainBase
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
        ///     Soru Id'si
        /// </summary>
        public int Question1Id { get; set; }

        /// <summary>
        ///     Soru Id'si
        /// </summary>
        public int Question2Id { get; set; }

        /// <summary>
        ///     Soru Id'si
        /// </summary>
        public int Question3Id { get; set; }

        /// <summary>
        ///     1. soru yanıtı
        /// </summary>
        public string Answer1 { get; set; }

        /// <summary>
        ///     2. soru yanıtı
        /// </summary>
        public string Answer2 { get; set; }

        /// <summary>
        ///     3. soru yanıtı
        /// </summary>
        public string Answer3 { get; set; }
    }
}