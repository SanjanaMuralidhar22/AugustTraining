using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTraining
{
    class MainClass
    {
        
        static IAnalyser exp = ExpenseFactory.getComponent();
        static void Main(string[] args)
        {


            User[] obj = new User[50];


            bool process = true;
            do
            {
                string menuFile = @"C:\Users\sanjanam\source\repos\TechnicalTrainingSolution\TechnicalTraining\Menu.txt";
                string menu = File.ReadAllText(menuFile);
                Console.WriteLine(menu);
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        ExpenseOfUser.AddData(ref obj);
                        break;
                    case 2:
                        ExpenseOfUser.DeleteData(ref obj);
                        break;
                    case 3:
                        ExpenseOfUser.UpdateData(ref obj);
                        break;
                    case 4:
                        ExpenseOfUser.ReadData(ref obj);
                        break;
                    case 5:
                        ExpenseOfUser.FindData(ref obj);
                        break;
                    case 6:exp.Statistics(obj);
                        break;
                    case 7:exp.TotalExpense(obj);
                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE");
                        process = false;
                        break;
                }
            } while (process);

        }
    }


    class ExpenseOfUser
    {
        public static void AddData(ref User[] obj)
        {
            for (int i = 1; i <= 20; i++)
            {
                int type = Utilities.GetInteger("Enter the category \n1.General \n2.Maintainance \n3.Food \n4.Travel \n5.Miscellaneous");
                int mon = Utilities.GetInteger("Enter the amount spent");
                m:
                string detail = Utilities.GetString("Enter the details");
                try
                {
                    
                    if (string.IsNullOrEmpty(detail))
                    {
                        
                        throw new Exception("Empty string input");
                    }

                    obj[i] = new User { Id = i, money = mon, Date = DateTime.Now, details = detail, category = type };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    goto m;
                }
                
                int ans = Utilities.GetInteger("Do you want to enter another data  0/1");
                if (ans == 0)
                    break;
            }
        }

        public static User[] FindData(ref User[] obj)
        {
            int id = Utilities.GetInteger("Enter the id you want to find");

            for (int i = 1; obj[i] != null; i++)
            {
                if (obj[i].Id == id)
                {
                    Console.WriteLine("Data Found");
                    Console.WriteLine($"Id: {obj[i].Id} \n Money: {obj[i].money} Details: {obj[i].details} ");
                }
            }
            return obj;
        }

        public static void ReadData(ref User[] obj)
        {
            int type = Utilities.GetInteger("Enter the category \n1.General \n2.Maintainance \n3.Food \n4.Travel \n5.Miscellaneous \n 6.All");
            if (type == 6)
            {
                for (int i = 1; obj[i] != null; i++)
                {
                    Console.WriteLine($"Id: {obj[i].Id} Money: {obj[i].money} Details: {obj[i].details} Type: {obj[i].category} Date: {obj[i].Date}");
                }

            }
            else
            {
                for (int i = 1; obj[i] != null; i++)
                {
                    // Console.WriteLine($"Id: {obj[i].Id} Money: {obj[i].money} Details: {obj[i].details} ");
                    if (obj[i].category == type)
                    {
                        Console.WriteLine($"Id: {obj[i].Id} Money: {obj[i].money} Details: {obj[i].details} Date: {obj[i].Date}");
                    }
                }
            }
        }

        public static void DeleteData(ref User[] obj)
        {
            int id = Utilities.GetInteger("Enter the id you want to Delete");

            for (int i = 1; obj[i] != null; i++)
            {
                if (obj[i].Id == id)
                {
                    obj[i] = null;
                    Console.WriteLine("Data deleted");
                    break;
                }
            }


        }

        public static void UpdateData(ref User[] obj)
        {
            int id = Utilities.GetInteger("Enter the id you want to find");
            for (int i = 1; obj[i] != null; i++)
            {
                if (obj[i].Id == id)
                {
                    int type = Utilities.GetInteger("Enter the category \n1.General \n2.Maintainance \n3.Food \n4.Travel \n5.Miscellaneous");
                    int mon = Utilities.GetInteger("Enter the amount spent");
                    string detail = Utilities.GetString("Enter the details");
                    obj[i] = new User { Id = i, money = mon, Date = DateTime.Now, details = detail, category = type };
                    break;
                }
            }
            Console.WriteLine("Update successfully");

        }
    }
    interface IAnalyser
    {
        void TotalExpense(User[] obj);

        void Statistics(User[] obj);


    }
    public class Analyser : IAnalyser
        {
            static IAnalyser exp = ExpenseFactory.getComponent();
            public void Statistics(User[] obj)
            {
                float sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, sumt = 0;
                for (int i = 1; obj[i] != null; i++)
                {
                    
                    if (obj[i].category == 1)
                    {
                        sum1 += obj[i].money;
                    }
                    if (obj[i].category == 2)
                    {
                        sum2 += obj[i].money;

                    }
                    if (obj[i].category == 3)
                    {
                        sum3 += obj[i].money;

                    }
                    if (obj[i].category == 4)
                    {
                        sum4 += obj[i].money;

                    }
                    if (obj[i].category == 5)
                    {
                        sum5 += obj[i].money;
                    }
                    sumt += obj[i].money;

                }
                Console.WriteLine($"Total Money spent in ....\n1.General-----{sum1}----{(sum1 / sumt) * 100}% \n2.Maintainance-----{sum2}----{(sum2 / sumt) * 100}%  \n3.Food-----{sum3}----{(sum3 / sumt) * 100}%  \n4.Travel-----{sum4}----{(sum4 / sumt) * 100}%  \n5.Miscellaneous-----{sum5}----{(sum5 / sumt) * 100}% ");



            }

            public void TotalExpense(User[] obj)
            {
                int amt = 0;
                for (int i = 1; obj[i] != null; i++)
                {
                    amt += obj[i].money;
                }
                Console.WriteLine($"Total Expensence Today {amt}");

            }
        }


    }

