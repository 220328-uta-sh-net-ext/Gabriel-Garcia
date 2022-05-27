class Animal
{
    readonly name: string;
    private species: string;

    constructor(name:string, species:string)
    {
        this.name = name;
        this.species = species;
    }
    get getSpecies(): string
    {
        return this.species;
    }
    set setSpecies(sp: string)
    {
        this.species = sp;
    }
    move(feet:number):void
    {
        console.log(`the animal ${this.name} moved a total of ${feet} feet`);
    }
}
let an = new Animal('Perry','Platypus');
an.move(5);
//quick call
an.setSpecies = 'Dog';
console.log(an.getSpecies);
//inheritance
class Dog extends Animal
{
    bark():void
    {
        console.log('Arf Arf');
    }
}
let m = new Dog('Mya','Boxer');
m.bark();
m.move(60);
//abstract classes
abstract class Car{
    abstract drive():void;
    alarm():void{
        console.log('Beeep')
    }
}
class sportCar extends Car{
    drive(): void{
        console.log('Driving');
    }
}
let sc = new sportCar();
sc.alarm();
sc.drive();

//interface
interface user{
    username: string;
    password: string;
    phone?: number;
    login(): boolean;
}

let user1:user;

user1 = {
    username: 'Leroy',
    password: 'jenkins',
    login: () => {return true}
}
let user2:user;

user2 = {
    username: 'bob',
    password: 'jill',
    phone: 9090090909,
    login: () => {return true}
}