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

class Greeter {
  element: HTMLElement;
  span: HTMLElement;
  timerToken: number;

  constructor(element: HTMLElement) {
    this.element = element;
    this.element.innerHTML += "The time is: ";
    this.span = document.createElement('span');
    this.element.appendChild(this.span);
    this.span.innerText = new Date().toUTCString();
  }

  start() {
    this.timerToken = setInterval(() => this.span.innerHTML = new Date().toUTCString(), 500);
  }

  stop() {
    clearTimeout(this.timerToken);
  }
}


class Pony {
  color: string;
}

let myNumber: number = 0;
let myString: string = "string";
let myPony: Pony = new Pony();
let myPonyList: Array<Pony> = [new Pony()];
let myAny: any = 2;
myAny = "string";
let myBoth: number | boolean = 2;
enum MyEnum { Start, Stop };
let myEnum1: MyEnum = MyEnum.Start;

function MyFunction1(str: string): string {
  return "hello";
}

function MyFunction2(str: string): void {
}

interface MyInterface1 {
  score: number;
}

function AddScore(my: MyInterface1, point?: number): void {
  point = point || 0;
  my.score = 1;
}



//

interface CanRun {
  run(str: string): void;

}

let myRun = {
  run: (str) => { alert("my string is ${str} !" + str); }
}

class MyRun {
  run(str) {
    alert("my string is ${str} !" + str);
  }
}

class MyRun1 implements CanRun {
  run(str) {
    alert("my string is ${str} !" + str);
  }
}


function startRun(myRun: CanRun): void {
  myRun.run("run");
}

//

class MyClass {
  constructor(public name: string, private _age: number) {
  }

  run() {
    alert("my string is ${this.name} !" + this.name);
  }
}


let LogTest = function () {
  return (target: any, name: string, descriptor: any) {
    alert(name);
    return descriptor;
  };
};

class MyTestLogClass {
  constructor(public name: string, private _age: number) {
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
  var greeter = new Greeter(el);
  let aa = "";

  greeter.start();

  //startRun(new MyRun1());
  let mmm1: MyTestLogClass = new MyTestLogClass("a", 1);
  mmm1.run();
};

