using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Membership.Data.DomainEfModel())
            {
                db.Database.Connection.Open();
                var list = db.Applications.ToList();
            }

                Console.ReadKey();
        }
    }
}
