class Person{
    constructor(firstName, lastName, age){
this.firstName = firstName;
this.lastName = lastName;
this.age = age;
    }
    sayHi(){
        console.log(`${this.firstName} says Hi!`);
    }
}

let myPerson = new Person('Peter', 'Pan', 25);

console.log(myPerson);
console.log(myPerson.age);
myPerson.age++;
console.log(myPerson.age);

let otherPerson = new Person('Jack', 'Sparrow', 'unknown');

console.log(otherPerson);

myPerson.sayHi();
otherPerson.sayHi();