using System;

namespace Restaurant_Event
{
    public class Customer
    {
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public enum Meals { 
            none = 0,
            appetizer = 1,
            main = 2 ,
            desert = 3,
            done = 4
        }
        public event MealHandler MealCourseChanged;
        public void OnEachMeal(string FirstName, string LastName ,int mealtype)
        {
            OnMealChanged(FirstName, LastName,Enum.GetName(typeof(Meals),mealtype));
        }
        protected virtual void OnMealChanged(string FName,string LName,string meal)
        {
            if (MealCourseChanged != null)
            {
                MealCourseChanged(this, new MealsChangedEventArgs(FName, LName, meal));
            }
        }
    }
    public delegate void MealHandler(object Customer, MealsChangedEventArgs mealargs);

    public class MealsChangedEventArgs : EventArgs
    {
        public string fName;
        public string lName;
        public string mealtype;

        public MealsChangedEventArgs(string fName, string lName, string meal)
        {
            this.fName = fName;
            this.lName = lName;
            this.mealtype = meal;
        }
    }
    public class MealsChangedEventHandler
    {
        public void NotifyCurrentMeal(object Customer,MealsChangedEventArgs mealargs)
        {
            if(mealargs.mealtype == "none")
            {
                Console.WriteLine($"{mealargs.fName} {mealargs.lName} got a table");
            }
            else
            {
                Console.WriteLine($"{mealargs.fName} {mealargs.lName} is having {mealargs.mealtype}");
            }
        }

    }
}
