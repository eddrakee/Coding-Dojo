using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // loop to print 1-255
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }

            // loop to print values 1-100 that are divisible by 3 or 5, not both
            for (int i = 1; i <= 100; i++)
            {
                if(i%3 == 0 || i%5 == 0   ){
                    if( i%3 == 0 && i%5 == 0){
                        continue;
                    }
                    else{
                        Console.WriteLine(i);
                    }
                }
            }
            // replace num divisible by 3 with "Fizz", 5 with "Buzz" and mutliples of both to "FizzBuzz"
            for (int i = 1; i <= 100; i++)
            {
                if(i%3 == 0){
                    Console.WriteLine("Fizz");
                }
                else if( i%5 == 0){
                    Console.WriteLine("Buzz");
                }
                if( i%3 == 0 && i%3 == 0){
                    Console.WriteLine("FizzBuzz");
                }
            }

            // Generate 10 random values and output the respective word for the generated values
            Random rand = new Random();
            for(int num = 0; num <= 100; num++){
                int val = rand.Next(1, 100);

                string output = "For attempt" + num + "the value is" + val + "and the word is";

                if(val%3 == 0 && val%5 == 0 ){
                    output += "FizzBuzz";
                }
                else if( val%3 == 0){
                    output += "Fizz";
                }
                else if( val%3 == 0){
                    output += "Buzz";
                }
                else{
                    output += "nothing!";
                }
                Console.WriteLine(output);
            }
            

        }
    }
}

