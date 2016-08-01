using System;
using System.Linq;

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
                var listW = db.WebUsers.ToList();

                foreach (var item in list)
                {
                    Console.WriteLine(item.ApplicationName);
                }

            }

            Console.ReadKey();
        }
    }
}