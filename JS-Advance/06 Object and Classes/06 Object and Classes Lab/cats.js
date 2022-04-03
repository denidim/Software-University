function cats(catsAsString) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        } 
        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    let cats = [];
    for (let catData of catsAsString) {
        let [name, age] = catData.split(' ');

        let cat = new Cat(name, age);
        cats.push(cat);
    }

    for (let cat of cats) {
        cat.meow();
    }

}
cats(['Mellow 2', 'Tom 5']);


