function PrintCats(input) {
    class Cat {
        constructor (name, age){
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (const key of input) {
        let [name, age] = key.split(' ');
        age = Number(age);

        new Cat(name, age).meow();
    }
}


PrintCats(['Candy 1', 'Poppy 3', 'Nyx 2']);