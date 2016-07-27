using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Core.Domain.Account
{
    [Table("Account")]
    public class Account : DomainBase
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
        ///     Benzersiz kayıt Id'si
        /// </summary>
        public string RegistrationId { get; set; }

        /// <summary>
        ///     Benzersiz kullanıcı kodu
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///     Kullanıcı email'i
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Kullanıcı şifresi
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Kullanıcı adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Kullanıcı soyadı
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        ///     Kimlik numarası
        /// </summary>
        public string IdentityNo { get; set; }

        /// <summary>
        ///     Cinsiyet
        /// </summary>
        public byte Gender { get; set; }

        /// <summary>
        ///     Gsm
        /// </summary>
        public string Gsm { get; set; }

        /// <summary>
        ///     Doğum tarihi
        /// </summary>
        public DateTime? BirthDate { get; set; }

        ///// <summary>
        /////     Enlem
        ///// </summary>
        //public string Latitude { get; set; }

        ///// <summary>
        /////     Boylam
        ///// </summary>
        //public string Longitude { get; set; }

        /// <summary>
        ///     Kullanıcı iletişim dili
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        ///     Hesap tipi
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        ///     Alternatif email
        /// </summary>
        public string AlternativeEmail { get; set; }

        /// <summary>
        ///     Risk seviyesi
        /// </summary>
        public int RiskLevel { get; set; }

        /// <summary>
        ///     Referans kullanıcı Id'si
        /// </summary>
        public int ReferenceAccountId { get; set; }

        /// <summary>
        ///     Kullanıcı son giriş tarihi
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        ///     Durumu
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        ///     Sistem durumu
        /// </summary>
        public byte SystemStatus { get; set; }

        /// <summary>
        ///     Benzersiz salt değeri
        /// </summary>
        public string Salt { get; set; }
    }
}