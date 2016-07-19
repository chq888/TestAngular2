//function sayHello() {
//  //const compiler = (document.getElementById("compiler") as HTMLInputElement).value;
//  //const framework = (document.getElementById("framework") as HTMLInputElement).value;
//  let isDone: boolean = false;
//  let decimal: number = 6;
//  let hex: number = 0xf00d;
//  let binary: number = 0b1010;
//  let octal: number = 0o744;
//  let sss: string = "";
//  let ir: number[] = [1, 2, 3];
//  let list: Array<number> = [1, 2, 3];
//  // Declare a tuple type
//  let x: [string, number];
//  // Initialize it
//  x = ["hello", 10]; // OK
//// Initialize it incorrectly
//  x[3] = "world"; // OK, 'string' can be assigned to 'string | number'
//  enum Color { Red, Green, Blue };
//  let c: Color = Color.Green;
//  enum MyColor { Red = 1, Green = 2 };
//  let mc: MyColor = MyColor.Red;
//  function f(shouldInitialize: boolean) {
//    if (shouldInitialize) {
//      var x = 10;
//    }
//    alert(x);
//  }
//  f(true);  // returns '10'
//  f(false); // returns 'undefined'
//  for (var i = 0; i < 3; i++) {
//    // capture the current state of 'i'
//    // by invoking a function with its current value
//    //(function (i) {
//    setTimeout(function () {
//      console.log(i);
//    }, 100 * i);
//    //})(i);
//  }
//  return "Hello from ${compiler} and ${framework}!";
//}
//sayHello(); 
//# sourceMappingURL=app.js.map