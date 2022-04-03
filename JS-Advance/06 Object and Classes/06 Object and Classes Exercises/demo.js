function solve(data) {


    data
    .map( el => {
        let [name, level, items] = el.split(' / ');
        items = items.split(', ').sort((a, b) => a.localeCompare(b)).join(', ');

        return {
            name,
            level: Number(level),
            items
        }
    })
    .sort((a, b) => a.level - b.level)
    .forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    });
}


solve([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara"
]);

solve(["Batman / 2 / Banana, Gun",
    "Superman / 18 / Sword",
    "Poppy / 28 / Sentinel, Antara"
]);
