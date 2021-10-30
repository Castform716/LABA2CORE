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
            addCustomer("3178618185", "+380996758212", "itdoesnthave@mail.ru", "795484823", "Entity");
            showTable();
            updateCustomer("3178618185", "Mark", "ZuckenBorg");
            showTable();
            deleteCustomer("3178618185");
            deleteCustomer("9145051732");
            showTable();
        }

        static void showTable()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                
                var lines = db.Customers.ToList();
                Console.WriteLine("\n Updated data");
                foreach (Customer c in lines)
                {
                    Console.WriteLine($"{c.Itn},{c.PhoneNumber}, {c.Email}, {c.FirstName}, {c.LastName}");
                }
            }
        }

        static void addCustomer(string ITN, string PhnNumb, string mail, string mfo, string individ)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                Customer custOne = new Customer { Itn = ITN, PhoneNumber = PhnNumb, Email = mail, LegalEntityIndividual = individ };

                db.Customers.Add(custOne);
                db.SaveChanges();
            }
        }

        static void updateCustomer(string ITN, string name, string lastname)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                
                Customer cust = db.Customers.Find(ITN);
                if (cust != null)
                {
                    cust.FirstName = name;
                    cust.LastName = lastname;
                    
                    db.Customers.Update(cust);
                    db.SaveChanges();
                }

            }
        }

        static void deleteCustomer(string ITN)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                
                Customer cust = db.Customers.Find(ITN);
                if (cust != null)
                {
                    db.Customers.Remove(cust);
                    db.SaveChanges();
                }

            }
        }

    }
}
