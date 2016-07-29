using Membership.Site.ActionFilters;
using System;
using System.Web.Mvc;

namespace Membership.Site.Base
{
    public class Constant
    {

        #region Web
        public class Web
        {

            public const String RedirectHomePage = "~/Dashboard/Index";
            public const String RedirectLoginPage = "~/SiteAuthenticate/Index";
            public const String RedirectLoginAction = "~/SiteAuthenticate/Signin";
            public const String RedirectLogoutAction = "~/SiteAuthenticate/Signout";
            public static readonly string[] UnAuthorizedActions = { "SiteAuthenticate/Index", "SiteAuthenticate/Signin", "SiteAuthenticate/Signout", "SiteAuthenticate/RememberPassword" };
            //public static readonly string[] SharedActions = { "Dashboard/Index" };
        }
        #endregion


        #region Message
        public class Message
        {
            #region Hata Mesajları
            public const String OperationNotCompleted = "OperationNotCompleted|İşlem tamamlanamadı.|Operation has not been completed.";
            public const String UserNotAuthorized = "UserNotAuthorized|Kullanıcı {0} yetkili değildir.|User {0} has not been authorized.";
            public const String UserAccessDenied = "UserAccessDenied|{0} işlemi için {1} kullanıcısının yetkisi bulunmamaktadır. | {1} has not access for {0} operation.";
            public const String RedirectToLogin = "RedirectToLogin|Oturum bilgisi bulunamadığından dolayı giriş sayfasına yönlendirileceksiniz. | because";
            public const String OperationCompleted = "OperationCompleted|İşlem tamamlandı.|Operation has been completed.";
            public const String ConfirmDelete = "ConfirmDelete|Silmek istiyor musunuz?|Do you want to delete?";
            public const String ValidateStartAndEndDate = "ValidateStartAndEndDate|Başlangıç tarihi, Bitiş tarihinden büyük olamaz.|EndDate must be greater than StartDate.";
            public const String UserPasswordDontMatch = "UserPasswordDontMatch|Kullanıcı şifresi ile girilen şifre uyuşmuyor|User Password and entered password do not match";
            public const String UserEnteredPasswordsDontMatch = "UserEnteredPasswordsDontMatch|Girilen şifreler birbirleri ile uyuşmuyor| Entered passwords do not match";
            #endregion


            #region Bilgi Mesajları
            public const String UserPasswordChanged = "UserPasswordChanged|Kullanıcı şifreniz başarılı bir şekilde değiştirildi.Şifre değişikliği sisteme tekrar giriş yaptığınızda geçerli olacak|Your user password was changed successfully. Password changes to the system will be available when you log back";
            #endregion
        }
        #endregion


        #region Exception
        public class ExceptionType
        {
            public const String DBContextNotInitialized = "DBContextNotInitializedException|DBContext hazırlanması aşamasında hata oluştu.|DBContext has not been initialized.";
            public const String ContextInitialization = "ContextInitializationException|Context hazırlanması aşamasında hata oluştu.|Context has not been initialized.";
            public const String RecordNotFound = "RecordNotFoundException|{0} parametresi ile kayıt bulunamamıştır.| Record with parameter {0} was not found.";
            public const String ItemNotFound = "ItemNotFoundException|{0} elemanı bulunamamıştır.|The item {0} was not found.";
            public const String NullValue = "NullValueException|Alanda değer yoktur.|The field has null value.";
            public const String InvalidType = "InvalidTypeException|{0} geçersiz tiptir.|The type {0} is invalid.";
            public const String InvalidInput = "InvalidInputException|Geçersiz bilgi girişi ile karşılaşılmıştır.|The input is invalid.";
            public const String EntityProcess = "DBException|Veritabanı işleminde hata oluştu.|Database operation has not been executed.";
            public const String DBDuplicateKey = "DBDuplicateKeyException|Aynı anahtar değerli kayıt bulunmaktadır.|Record with same key exists in the database.";
            public const String AuthenticationFailed = "AuthenticationFailedException|Kimlik belirleme işlemi başarısız oldu.|Authentication has not been succeeded.";
            public const String WrongPassword = "WrongPasswordException|<br>Şifre hatalıdır.10 dakika içinde {0} defa yanlış şifre girmeniz durumunda son girilen hesap kilitlenecektir.<br><b>Kalan Hakkınız: {1}<b/> | <br>Password is wrong.If you enter the wrong password {0} times in 10 minutes, The last entered account will be locked.<br><b>Remaining Trial: {1}<b/>";
            public const String ForceChangePassword = "ForceChangePasswordException|Şifre değiştirilmelidir.|Password must be changed.";
            public const String MissingFeature = "MissingFeatureException|{0} Özelliği henüz geliştirilmemiştir.|The feature {0} is missing.";
            public const String Security = "SecurityException|Güvenlik problemi bulunmaktadır.|Application has a security problem.";
            public const String Configuration = "ConfigurationException|Konfigurasyon erişimi problemi bulunmaktadır.|Application has a configuration access problem.";
        }
        #endregion

    }
}
