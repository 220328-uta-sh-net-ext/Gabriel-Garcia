"use strict";
class Animal {
    constructor(name, species) {
        this.name = name;
        this.species = species;
    }
    get getSpecies() {
        return this.species;
    }
    set setSpecies(sp) {
        this.species = sp;
    }
    move(feet) {
        console.log(`the animal ${this.name} moved a total of ${feet} feet`);
    }
}
let an = new Animal('Perry', 'Platypus');
an.move(5);
//quick call
an.setSpecies = 'Dog';
console.log(an.getSpecies);
//inheritance
class Dog extends Animal {
    bark() {
        console.log('Arf Arf');
    }
}
let m = new Dog('Mya', 'Boxer');
m.bark();
m.move(60);
//abstract classes
class Car {
    alarm() {
        console.log('Beeep');
    }
}
class sportCar extends Car {
    drive() {
        console.log('Driving');
    }
}
let sc = new sportCar();
sc.alarm();
sc.drive();
let user1;
user1 = {
    username: 'Leroy',
    password: 'jenkins',
    login: () => { return true; }
};
let user2;
user2 = {
    username: 'bob',
    password: 'jill',
    phone: 9090090909,
    login: () => { return true; }
};
