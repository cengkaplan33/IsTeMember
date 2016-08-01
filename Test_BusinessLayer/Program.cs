using System;

namespace Test_BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ss = new Membership.Business.Manager.WebUserManager().LoggedUser("ok@g.com");
                Console.WriteLine(ss.DisplayName);
            }
            catch (Exception ex)
            {
            }
            Console.ReadKey();
        }
    }
}