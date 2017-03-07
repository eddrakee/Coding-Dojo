using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an empty List of type object
            List<object> listObj = new List<object>();

            // Add these items to the list
            listObj.Add(7);
            listObj.Add(28);
            listObj.Add(-1);
            listObj.Add(true);
            listObj.Add("chair");

            // Loop through the list and display all values and sum all integers
            int sum = 0;
            foreach(var obj in listObj){
                System.Console.WriteLine(obj);
                if(obj is int){
                    sum += (int)obj;
                }
            }
            System.Console.WriteLine("The sum of all integers is {0}", sum);
        }
    }
}
