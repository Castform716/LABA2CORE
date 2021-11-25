using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace LABA2CORE
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BankSystemContext db = new BankSystemContext())
            {

                //CountBanks();

                //GetBanks(2);

                //DescendOrderBanks();

                //ParamCustGet(51000, "Lif");

                //crossJoin();

                //IntersectTest();

                //UnionTestCustCards();

                //CustomOrderBy(2, 2);

                //TransactionsSumMaxMin(1); //1 - sum, 2 - max, 3 - min


                FunctionTest(10000.0f);

                //StorProcedureTest("353656", "14360570", "7954824724");
                //showAccounts();

                 Console.Read();
            }



            //showTable();
            //addCustomer("9145051732", "+380504848501", "whyisitsohard@gmail.com", "456634663", "Individual");
            //addCustomer("3178618185", "+380996758212", "itdoesnthave@mail.ru", "795484823", "Entity");
            //showTable();
            //updateCustomer("3178618185", "Mark", "ZuckenBorg");
            //showTable();
            //deleteCustomer("3178618185");
            //deleteCustomer("9145051732");
            //showTable();
        }



        static void StorProcedureTest(string accountNum, string USREOU, string ITN)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var accNumb = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@AccNumber",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    SqlValue = accountNum,
                    Size = 18
                };

                var USR = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@USREOU",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    SqlValue = USREOU,
                    Size = 10
                };

                var itn = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@ITN",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    SqlValue = ITN,
                    Size = 20
                };

                db.Database.ExecuteSqlRaw("EXEC AddAccount @AccNumber, @USREOU, @ITN", accNumb, USR, itn); ;

            }
        }

        static void FunctionTest(float bordVal)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                Microsoft.Data.SqlClient.SqlParameter border = new Microsoft.Data.SqlClient.SqlParameter("@Value", bordVal);
                var allBetter = db.Employees.FromSqlRaw("SELECT * FROM dbo.SallaryAboveVal (@Value)", border).ToList();
                foreach (var empl in allBetter)
                    Console.WriteLine("{0}, {1} - {2}", empl.FirstName, empl.Sallary, bordVal);

            }
        }

        static void TransactionsSumMaxMin(int arg)
        {

            if (arg < 1 || arg > 3)
            {
                Console.WriteLine("Whoops, not a number");
            }
            else
            {
                switch (arg)
                {
                    case 1:
                        GetTransactSum();
                        break;
                    case 2:
                        GetTransactMax();
                        break;
                    case 3:
                        GetTransactMin();
                        break;
                }
            }
        }

        static void GetTransactSum()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var sum = db.Transactions.Sum(x => x.BalanceChange);
                Console.WriteLine(sum);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void GetTransactMax()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var max = db.Transactions.Max(x => x.BalanceChange);
                Console.WriteLine(max);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void GetTransactMin()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var min = db.Transactions.Min(x => x.BalanceChange);
                Console.WriteLine(min);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void crossJoin()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var join= db.Cards.Join(db.Customers,
                       x => x.Itn,
                       y => y.Itn, (x, y) => new
                       {
                           ITN = x.Itn,
                           FirstName = y.FirstName
                       });
                foreach (var j in join)
                    Console.WriteLine("{0}  {1}", j.ITN, j.FirstName);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void IntersectTest()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var e = db.Cards.Select(x => new { ITN = x.Itn })
                .Intersect(db.Customers.Select(x => new { ITN = x.Itn }));
                foreach (var x in e)
                    Console.WriteLine(x.ITN);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void UnionTestCustCards()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var u = db.Cards.Select(x => new { ITN = x.Itn })
                                         .Union(db.Customers.Select(x => new { ITN = x.Itn }));
                foreach (var x in u)
                    Console.WriteLine(x.ITN);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        static void ParamCustGet(float trust, string partName)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var tempCust = db.Customers.Where(x => x.TrustLimit >= trust)
                                     .Where(x => x.FirstName.Contains(partName));
                foreach (Customer cust in tempCust)
                    Console.WriteLine("{0} - {1} {2}", cust.TrustLimit, cust.FirstName, cust.LastName);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void CustomOrderBy(int skipAmount, int takeAmount)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var tempCust = db.Customers.OrderBy(x => x.TrustLimit)
                                    .Skip(skipAmount)
                                    .Take(takeAmount);
                foreach (Customer cust in tempCust)
                    Console.WriteLine("{0} - {1} {2}", cust.TrustLimit, cust.FirstName, cust.LastName);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void DescendOrderBanks()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var tempBanks = db.Banks.OrderByDescending(x => x.OverallBalance);
                foreach (Bank ba in tempBanks)
                    Console.WriteLine("{0}  {1}", ba.Name, ba.OverallBalance);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void CountBanks()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var tempBanks = db.Banks.Count();
                Console.WriteLine("Banks amount - {0}", tempBanks);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        static void GetBanks(int num)
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                var tempBank = db.Banks.Take(num);
                foreach (Bank banks in tempBank)
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", banks.Usreou, banks.Name, banks.Departments, banks.OverallBalance, banks.GoldCapacity, banks.OriginCountry);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void showAccounts()
        {
            using (BankSystemContext db = new BankSystemContext())
            {

                var lines = db.Accounts.ToList();
                Console.WriteLine("\n Updated data");
                foreach (Account c in lines)
                {
                    Console.WriteLine($"{c.Itn},{c.Usreou}, {c.AccountNumber}");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine();
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
