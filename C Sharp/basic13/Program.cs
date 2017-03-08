using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        //Print 1 to 255 
        public static void Print1to255() {
            for(int val=1; val < 256; val++) {
                Console.WriteLine(val);
            }
        }
        // Print odd numbers between 1 to 255
        public static void PrintOdd(){
            for (int val=1; val < 256; val +=2 ){
                System.Console.WriteLine(val);
            }
        }

        // Print sum of 0 to 255
        public static void PrintSum255(){
            int sum = 0;
            for( int val=0; val<256; val ++){
                sum += val;
                System.Console.WriteLine($"New number {sum} - Current number {val}");
            }
        }
        // Iterate through a given Array
        public static void iteratateArray(int[] arr){
            string statement = "The array in order: [";
            for( int i = 0; i < arr.Length; i ++){
                statement += arr[i] + ", ";
            }
            statement += "]";
            System.Console.WriteLine(statement);
        }

        // Find max value in array
        public static void findMax(int[] arr){
            int max = arr[0];
            for( int i = 0; i < arr.Length; i ++){
                if( arr[i] > max){
                    max = arr[i];
                }
            }
            System.Console.WriteLine("The max value is {0}", max);
        }
        // NEED TO REDO THESE BELOW:
        //Get average value of an array
        public static void AvgOfArray(int[] arr) {
            int sum = GetSum(arr);
            Console.WriteLine("This average is " + (double)sum/(double)arr.Length);
        }
        public static int GetSum(int[] arr) {
            int sum = 0;
            for(int num = 0; num < arr.Length; num++) {
                sum += arr[num]; //sum = sum + num
            }
            return sum;
        }

        //Create arr of odd numbers between 1 and 255
        public static int[] CreateOddArray() {
            List<int> oddList = new List<int>();
            for(int val = 1; val < 256; val++) {
                if(val % 2 == 1) {
                    oddList.Add(val);
                }
            }
            return oddList.ToArray();
        }

        //Count all values greater than myArr
        public static void GreaterThanY(int[] arr, int y) {
            int count = 0;
            foreach(int val in arr){
                if(val > y) {
                    count++;
                }
            }
            Console.WriteLine($"There are {count} values greater than {y}");
        }

        //Square all values in an arr
        public static void SquareArrayValues(int[] arr) {
            for(int idx = 0; idx < arr.Length; idx++) {
                arr[idx] *= arr[idx];
            }
        }

        //Elimate Negative Numbers in an array
        public static void ReplaceNegatives(int[] arr) {
            for(int idx = 0; idx < arr.Length; idx++) {
                if(arr[idx] < 0) {
                    arr[idx] = 0;
                }
            }
        }

        //Retrieve the min, max, and average values from an array
        public static void MinMaxAvg(int[] arr) {
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            foreach(int val in arr) {
                sum += val;
                if(val < min) {
                    min = val;
                }
                if(val > max) {
                    max = val;
                }
            }
            Console.WriteLine("The max of the array is {0}, the min is {1}, and the average is {2}", max, min, (double)sum/(double)arr.Length);
        }

        //Shift an array to the front by one number and add 0 to the end
        public static void ShiftLeft(int[] arr) {
            for(int idx = 0; idx < arr.Length - 1; idx++){
                arr[idx] = arr[idx + 1];
            }
            arr[arr.Length - 1] = 0;
        }

        //replace negatives with "dojo"
        public static object[] ReplaceNumberWithString(object[] arr) {
            for(int idx = 0; idx < arr.Length; idx++) {
                if((int)arr[idx] < 0) {
                    arr[idx] = "Dojo";
                }
            }
            return arr;
        }

        public static void Main(string[] args)
        {
        Print1to255();
        PrintOdd();
        PrintSum255();
        int[] myArr = new int[5] {3,10,51,2,11};
        iteratateArray(myArr);
        int[] maxArr = new int[5] {3,21, 52,22,1};
        findMax(maxArr);

        // REDO THESE BELOW:

        AvgOfArray(myArr);
        CreateOddArray();
        GreaterThanY(myArr, 4);
        SquareArrayValues(myArr); //Passed by reference
        ReplaceNegatives(myArr); //Passed by reference
        ShiftLeft(myArr);
        MinMaxAvg(myArr);
        ShiftLeft(myArr);
        object[] boxedArray = new object[] {-1, 3, 2 -16};
        ReplaceNumberWithString(boxedArray);
        }

    }
}
