function SortHeroes(input) {
    let heroes = [];
    for (const line of input) {
        let [name, level, items] = line.split(' / ');
        level = Number(level);
        heroes.push({ name, level, items });
    }

    let sorted = heroes.sort((heroA, heroB) => heroA.level - heroB.level);

    for (const {name,level,items} of sorted) {
        console.log(`Hero: ${name}`);
        console.log(`level => ${level}`);
        console.log(`items => ${items}`);
    }
}

SortHeroes([

    'Isacc / 25 / Apple, GravityGun',

    'Derek / 12 / BarrelVest, DestructionSword',

    'Hes / 1 / Desolator, Sentinel, Antara'

]);