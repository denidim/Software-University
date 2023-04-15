function Towns(input) {
    let towns = [];

    for (const item of input) {
        let splitted = item.split(' | ');
        townObj = {
            town: splitted[0],
            latitude: Number(splitted[1]).toFixed(2),
            longitude: Number(splitted[2]).toFixed(2),
        }

        towns.push(townObj)
    }

    for (const item of towns) {
        console.log(item);
    }
}


Towns(['Sofia | 42.696552 | 23.32601',

    'Beijing | 39.913818 | 116.363625'])