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
class Pony {
}
let myNumber = 0;
let myString = "string";
let myPony = new Pony();
let myPonyList = [new Pony()];
let myAny = 2;
myAny = "string";
let myBoth = 2;
var MyEnum;
(function (MyEnum) {
    MyEnum[MyEnum["Start"] = 0] = "Start";
    MyEnum[MyEnum["Stop"] = 1] = "Stop";
})(MyEnum || (MyEnum = {}));
;
let myEnum1 = MyEnum.Start;
function MyFunction1(str) {
    return "hello";
}
function MyFunction2(str) {
}
function AddScore(my, point) {
    point = point || 0;
    my.score = 1;
}
let myRun = {
    run: (str) => { alert("my string is ${str} !" + str); }
};
class MyRun {
    run(str) {
        alert("my string is ${str} !" + str);
    }
}
class MyRun1 {
    run(str) {
        alert("my string is ${str} !" + str);
    }
}
function startRun(myRun) {
    myRun.run("run");
}
//
class MyClass {
    constructor(name, _age) {
        this.name = name;
        this._age = _age;
    }
    run() {
        alert("my string is ${this.name} !" + this.name);
    }
}
let LogTest = function () {
    return (target, name, descriptor) => {
        alert(name);
        return descriptor;
    };
};
class MyTestLogClass {
    constructor(name, _age) {
        this.name = name;
        this._age = _age;
    }
    run() {
        alert("my string is ${this.name} !" + this.name);
    }
}
function greeter(person) {
    return "Hello, " + person;
}
var user = "Jane User";
//document.body.innerHTML = greeter(user);
window.onload = () => {
    var el = document.getElementById('content');
    let aa = "";
    //startRun(new MyRun1());
    let mmm1 = new MyTestLogClass("a", 1);
    mmm1.run();
};
//# sourceMappingURL=app.js.map