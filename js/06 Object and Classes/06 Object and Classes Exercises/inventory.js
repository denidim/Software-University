function inventory(list) {

    let heroes = [];

    for (let heroString of list) {
        let tokens = heroString.split(' / ');

        let name = tokens[0];
        let level = Number(tokens[1]);
        let items = tokens[2].split(', ');

        let heroData = {
            name,
            level,
            items
        };
        heroes.push(heroData);
    }

    let sortedHeroes = heroes.sort((a, b) => a.level - b.level);

    for (let hero of sortedHeroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.sort((a, b) => a.localeCompare(b)).join(', ')}`);
    }
}

inventory([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara"
]);

inventory(["Batman / 2 / Banana, Gun",
    "Superman / 18 / Sword",
    "Poppy / 28 / Sentinel, Antara"
]);