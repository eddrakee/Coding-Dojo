using System;

namespace ConsoleApplication
{
    public class Program
    {
        // Create funtion RandomArray that returns an int[]. Give it 10 random integer values and print min, max and sum
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] randomArr = new int[10];
            int sum = 0;
            int min = randomArr[0];
            int max = randomArr[0];
            for (int i = 0; i < randomArr.Length; i++)
            {
                int randomNum = rand.Next(5, 26);
                randomArr[i] = randomNum;
                System.Console.WriteLine(randomNum);
                sum += randomNum;
                // I don't know if this min function works. It gives 0 every time...
                if (randomArr[i] < min)
                {
                    min = randomArr[i];
                }
                else if (randomArr[i] > max)
                {
                    max = randomArr[i];
                }
            }
            System.Console.WriteLine($"The min value is {min}, the max value is {max} and the sum is {sum}");
            return randomArr;
        }
        // SOLUTION FROM ANSWER KEY:
        // public int[] RandomArray()
        // {
        //     Random rand = new Random();
        //     int[] randArr = new int[10];
        //     int sum = 0;
        //     for (int idx = 0; idx < randArr.Length; idx++)
        //     {
        //         //Up to 26 since .Next is non-inclusive
        //         int val = rand.Next(5, 26);
        //         randArr[idx] = val;
        //         sum += val;
        //     }
        //     Console.WriteLine("The max value of the random array is {0}", randArr.Max());
        //     Console.WriteLine("The min value of the random array is {0}", randArr.Min());
        //     return randArr;
        // }

// ********************************************************************************************************
        // Create a function called TossCoin() that returns a string
        // Have the function write either Heads or Tails, then return the result.

        // Create another function called TossMultipleCoins(int num) that returns a Double

        // Have the function call the tossCoin function multiple times (based on the num value passed) and return a Double that reflects the ratio between heads tossed to total tosses
        public static string TossCoin()
        {
            Random rand = new Random();
            System.Console.WriteLine("Tossing!");
            string result = "Heads";
            if (rand.Next() == 0)
            {
                result = "Tails";
            }
            System.Console.WriteLine(result);
            return result;
        }
        // FROM ANSWER KEY:
            // public string TossCoin(Random rand) {
            // Console.WriteLine("Tossing a Coin!");
            // string result = "Tails";
            // if(rand.Next() == 0) {
            //     result = "Heads";
            // }
            // Console.WriteLine(result);
            // return result;
            // }
    // ********************************************************************************************************

         public static Double TossMultipleCoins(int num){
            int numHeads = 0;
            for(int reps = 0; reps < num; reps++){
                if(TossCoin(new Random()) == "Heads"){
                    numHeads++;
                }
            }
            return (double)numHeads/(double)num;
        }

        public string[] Names() {
            string[] names = new string[5] {"Todd","Tiffany","Charlie","Geneva","Sydney"};
            //Fisher-Yates Shuffle
            Random rand = new Random();
            for(var idx = 0; idx < names.Length - 1; idx++){
                int randIdx = rand.Next(idx + 1, names.Length - 1);
                string temp = names[idx];
                names[idx] = names[randIdx];
                names[randIdx] = temp;
                //Print each name in it's new position
                Console.WriteLine(names[idx]);
            }
            //Don't forget the last value!
            Console.WriteLine(names[names.Length - 1]);

            //Return an array the only includes names longer than 5
            List<string> nameList = new List<string>();
            foreach(var name in names) {
                nameList.Add(name);
            }
            return nameList.ToArray();
        }
        public static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultiple(5);
        }
    }
}
