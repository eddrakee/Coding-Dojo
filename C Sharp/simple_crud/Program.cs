using System;
using System.Collections.Generic;
using DbConnection;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Add a user!
            System.Console.WriteLine("- Add a User -");

            System.Console.WriteLine("Please enter your first name");
                string first = Console.ReadLine();
            System.Console.WriteLine("Please enter your last name");
                string last = Console.ReadLine();
            System.Console.WriteLine("Please enter your favorite number");
                string num = Console.ReadLine();
            
            DbConnector.Execute("INSERT INTO users(FirstName, LastName, FavoriteNumber)VALUES ('"+first+"','"+last+"','"+num+"')");
            System.Console.WriteLine(first+" "+last+"'s favorite number is "+num);

            // Read them users!
            Console.WriteLine("- Here are all the Users -");
            // dbconnector.query is for queries with a expected return
            List<Dictionary<string, object>> users = DbConnector.Query("SELECT * from Users");
            foreach(var user in users){
                System.Console.WriteLine(user["FirstName"]);
            }
            // Create a new User 
            // dbconnector.execute is for queries without an expected return
            DbConnector.Execute("INSERT INTO users(FirstName, LastName, FavoriteNumber)VALUES ('Larry', 'Barry', 34)");
            System.Console.WriteLine("- This User Has Been Created -");

        }
    }
}
