using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Customer
{
    [Table("CustomerUser")]
    public class CustomerUser : DomainBase
    {
        /// <summary>
        ///     Internal Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Müşteri Id'si
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}