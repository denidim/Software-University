function inventory(list) {

    let heroes = [];

    for(let heroInfo of list){

        let [name, level, items] = heroInfo.split(' / ');
       let splited = items.split(', ')
        splited.sort((a, b) => a.localeCompare(b));

        let hero = {
            name: name,
            level: Number(level),
            items: splited
        };
        heroes.push(hero);
    }
    let sortedLevel = heroes.sort((a, b) => a.level - b.level);

    sortedLevel.forEach(hero =>{
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    });    
}

inventory([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara"
    ]);