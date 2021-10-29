using System;
using System.Linq;

namespace LABA2CORE
{
    class Program
    {
        static void Main(string[] args)
        {
            showTable();
            addCustomer("9145051732", "+380504848501", "whyisitsohard@gmail.com", "456634663", "Individual");
            addCustomer("3178618185", "+380996758212", "itdoesnthavetobethisway@mail.ru", "795484823", "Entity");


        }

        static void showTable()
        {
            using (ApplicContext db = new ApplicContext())
            {
                
                var lines = db.Customers.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (Customer c in lines)
                {
                    Console.WriteLine($"{c.Itn}. {c.PhoneNumber}, {c.Email}");
                }
            }
        }

        static void addCustomer(string ITN, string PhnNumb, string mail, string mfo, string individ)
        {
            using (ApplicContext db = new ApplicContext())
            {
                Customer custOne = new Customer { Itn = ITN, PhoneNumber = PhnNumb, Email = mail, LegalEntityIndividual = individ };

                db.Customers.Add(custOne);
                db.SaveChanges();
            }
        }
    }
}
