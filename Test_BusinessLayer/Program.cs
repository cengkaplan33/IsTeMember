using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

           
            var ss = new Membership.Business.Manager.WebUserManager().LoggedUser("ok@g.com");
            }
            catch (Exception ex)
            {
            }
            Console.ReadKey();
        }
    }
}
