using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Security
{
    [Table("ApiUser")]
    public class ApiUser : DomainBase
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

        /// <summary>
        ///     ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        ///     SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        ///     Benzersiz salt değeri
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}