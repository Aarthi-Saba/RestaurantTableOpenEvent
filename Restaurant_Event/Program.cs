using System;
using System.Collections.Generic;
namespace Restaurant_Event
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<Customer> CustomerQueue = new Queue<Customer> ();
            CustomerQueue.Enqueue(new Customer { CustFirstName = "Lorry", CustLastName = "Ben" });
            CustomerQueue.Enqueue(new Customer { CustFirstName = "James", CustLastName="Dave" });
            CustomerQueue.Enqueue(new Customer { CustFirstName = "Tom", CustLastName = "Hanks" });
            CustomerQueue.Enqueue(new Customer { CustFirstName = "Kelly", CustLastName = "Jones"});
            CustomerQueue.Enqueue(new Customer { CustFirstName = "Rick", CustLastName = "Dan" });

            Table tableobj = new Table();
            MealsChangedEventHandler mealchangedobj = new MealsChangedEventHandler();
            TableOpenEventHandler tableopenobj = new TableOpenEventHandler();
            foreach ( Customer cust in CustomerQueue)
            {
                tableobj.TableOpen += tableopenobj.TableOpenMessage;
                tableobj.MealFinished();
                tableobj.TableOpen -= tableopenobj.TableOpenMessage;
                cust.MealCourseChanged += mealchangedobj.NotifyCurrentMeal;
                for(int i=0; i < Enum.GetNames(typeof(Customer.Meals)).Length;i++)
                {
                    cust.OnEachMeal(cust.CustFirstName, cust.CustLastName, i);
                }
            }
            Console.WriteLine("Everyone is Full !");
        }
    }
}
