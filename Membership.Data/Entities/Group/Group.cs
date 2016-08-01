using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Group
{
    [Table("Group")]
    public class Group : DomainBase
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
        ///     Dizin Id'si
        /// </summary>
        public int DirectoryId { get; set; }

        /// <summary>
        ///     Benzersiz grup kodu
        /// </summary>
        public string GroupCode { get; set; }

        /// <summary>
        ///     Grup adı
        /// </summary>
        public string GroupName { get; set; }

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