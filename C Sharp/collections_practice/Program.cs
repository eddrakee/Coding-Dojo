using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create three basic arrays
            System.Console.WriteLine("- Three Basic Arrays -");

            System.Console.WriteLine("- One -");
            int[] arrayOne = new int[10] {0,1,2,3,4,5,6,7,8,9};

            System.Console.WriteLine("- Two -");
            string [] nameArray = new string[]{"Tim", "Martin", "Nikki", "Sarah"};

            System.Console.WriteLine("- Three -");
            bool [] boolArray = new bool[10];
            bool output = true;
            for (int i = 0; i<10; i++)
            {
                boolArray[i]=output;
                output = !output;
                System.Console.WriteLine(boolArray[i]);
            }

            // Create a multiplication table
            System.Console.WriteLine("- Multiplication Table -");

            int[,] mutliTable = new int [10,10];
            for (int x = 0; x <10; x++)
            {
                for(int y = 0; y <10; y++)
                {
                    mutliTable[x,y] = (x + 1) * (y + 1);
                }
            }

            for(int x = 0; x <10; x++)
            {
                string display = "[";
                for (int y = 0; y<10; y++)
                {
                    display += mutliTable[x,y] + ", ";
                    if(mutliTable[x,y] < 10)
                    {
                        display += " ";
                    }
                }
                display += "]";
                System.Console.WriteLine(display);
            }
            
            // Create a list of ice cream flavors that holds at least 5 different flavors
            // 1. Output the length, 2. Remove the 3rd flavor, 3. Output the new length
            System.Console.WriteLine("- Flavor Table -");

            List<string> flavors = new List<string>();
            flavors.Add("Pistachio");
            flavors.Add("Vanilla");
            flavors.Add("Coconut");
            flavors.Add("Butter Pecan");
            flavors.Add("Banana");
            System.Console.WriteLine(flavors.Count);
            System.Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            System.Console.WriteLine(flavors.Count);

            // User info directory - create a dictrionary taht will store both string keys and string values
            // 1. For each name in the array, add it as  anew key in this dictionary with value null
            // 2. For each name key, select a random flavor from ice cream list and store it as the value
            // 3. Loop through the Dictionary and print out each user's name and associated ice cream flavor

            Dictionary<string, string> userList = new Dictionary <string, string>();
            Random rand = new Random();
            foreach(string name in nameArray)
            {
                userList[name] = flavors[rand.Next(flavors.Count)];
            }
            System.Console.WriteLine("Users and their Favorite Flavor ");
            foreach(KeyValuePair<string, string> info in userList)
            {
                System.Console.WriteLine(info.Key + " - " + info.Value);
            }
        }
    }
}



