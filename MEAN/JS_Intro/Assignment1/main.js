  var x = [3,5,"Dojo", "rocks", "Michael", "Sensei"]
    console.log(x)

    x.push(100)
    console.log(x)

   x.push(['hello', 'world', 'JavaScript is Fun'])
   console.log(x)
   
   sum = 0;
   for (var i = 0; i < 500; i ++){
       sum += i;
   }
   console.log(sum);

   var arr = [1,5,90,25,-3,0]
   min = arr[0]
   sum1 = 0
   avg = arr[0]
   for (var i = 0; i<arr.length; i ++){
       if(arr[i] < min){
           min = arr[i];
       }
   }
   console.log(min);
   for (var i = 0; i<arr.length; i ++){
       sum1 += arr[i];
   }
   avg = sum1/arr.length
   console.log(avg)

//Object

 var new_ninja = {
 name: 'Jessica',
 profession: 'coder',
 favorite_language: 'JavaScript', //like that's even a question!
 dojo: 'Dallas'
}
for (var key in new_ninja){
    console.log(key, new_ninja[key]);
}

//Answer Key:
// / Set up array variable
// var x =  [3,5,"Dojo", "rocks", "Michael", "Sensei"];

// // Print all values in array
// for (var i = 0; i < x.length; i++) {
//   console.log(array[i]);
// }

// // Push the value 100 into the array
// x.push(100);

// // Push another array to array x
// x.push(["hello", "world", "JavaScript is Fun"]);

// console.log(x);

// // Print all the sum of numbers from 1-500
// var sum = 0;
// for (var i = 1; i < 501; i++) {
//   sum += i;
// }
// console.log(sum);


// // Find minimum value of following array
// var array = [1,5,90,25,-3,0];

// var min = array[0];
// for (var i = 1; i < arr.length; i++) {
//   if (arr[i] < min){
//     min = arr[i];
//   }
// }
// console.log(min);

// // Find average value of array
// var sum = arr[0];
// for (var i = 1; i < array.length; i++) {
//     sum  += arr[i];
// }
// console.log(sum/arr.length);

// // Iterate through object
// var new_ninja = {
//   name: 'Jessica',
//   profession: 'coder',
//   favorite_language: 'JavaScript',
//   dojo: 'Dallas'
// };

// for (var key in new_ninja){
//   console.log(key + " : " + new_ninja[key]);
// }