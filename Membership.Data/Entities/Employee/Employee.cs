using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Employee
{
    [Table("Employee")]
    public class Employee : DomainBase
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
        ///     Bayi Id'si
        /// </summary>
        public int ResellerId { get; set; }

        /// <summary>
        ///     Kullanıcı Id'si
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        ///     Benzersiz çalışan kodu
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Meslegi/Görev Tanımı
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        ///     Adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Soyadı
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        ///     Doğum yeri
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        ///     Eğitim durumu
        /// </summary>
        public string EducationLevel { get; set; }

        /// <summary>
        ///     Acil durumda ulaşılacak kişi
        /// </summary>
        public string EmergencyCallName { get; set; }

        /// <summary>
        ///     Acil durumda ulaşılacak kişi gsm’i
        /// </summary>
        public string EmergencyCallPhone { get; set; }

        // <summary>
        ///     Uyruğu
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }
    }
}