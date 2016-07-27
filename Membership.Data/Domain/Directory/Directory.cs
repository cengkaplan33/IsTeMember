using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Directory
{
    [Table("Directory")]
    public class Directory : DomainBase
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
        ///     Benzersiz dizin kodu
        /// </summary>
        public string DirectoryCode { get; set; }

        /// <summary>
        ///     Dizin adı
        /// </summary>
        public string DirectoryName { get; set; }

        /// <summary>
        ///     Açıklama
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}