using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Web
{
    [Table("WebUser")]
    public class WebUser : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Uygulama Id'si
        /// </summary>
        public int ApplicationId { get; set; }

        [MaxLength(30)]
        public string DisplayName;

        [MaxLength(200)]
        public string PasswordHash;

        [MaxLength(10)]
        public string PasswordSalt;

        [MaxLength(20)]
        public string Password;

        /// <summary>
        /// Aynı zamanda username için kullanılacak unique olmalı ve site girişlerinde kullanılacak.
        /// </summary>
        public string Email;
    }
}