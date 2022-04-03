function pianist(input) {
    let n = Number(input.shift());
    let list = {};

    for (let i = 0; i < n; i++) {
        let line = input.shift().split('|');
        let piece = line[0];
        let composer = line[1];
        let key = line[2];
        list[piece] = {
            composer,
            key
        };
    }

    while (input[0] !== 'Stop') {
        let [command, ...rest] = input.shift().split('|');

        if (command === 'Add') {
            let piece = rest[0];
            let composer = rest[1];
            let key = rest[2];
            if (list.hasOwnProperty(piece)) {

                console.log(`${piece} is already in the collection!`);
            } else {

                list[piece] = {
                    composer,
                    key
                };
                console.log(`${piece} by ${composer} in ${key} added to the collection!`);
            }

        } else if (command === 'Remove') {
            let piece = rest[0];
            if (list.hasOwnProperty(piece)) {
                delete list[piece];
                console.log(`Successfully removed ${piece}!`);
            } else {
                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            }

        } else if (command === 'ChangeKey') {
            let piece = rest[0];
            let newKey = rest[1];
            if (list.hasOwnProperty(piece)) {
                list[piece].key = newKey;
                console.log(`Changed the key of ${piece} to ${newKey}!`);
            } else {
                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            }
        }
    }
    for (let pieceData of Object.entries(list)) {

        let piece = pieceData[0];
        let composer = list[piece].composer;
        let key = list[piece].key;
        console.log(`${piece} -> Composer: ${composer}, Key: ${key}`);
    }

}
pianist([
    '3',
    'Fur Elise|Beethoven|A Minor',
    'Moonlight Sonata|Beethoven|C# Minor',
    'Clair de Lune|Debussy|C# Minor',
    'Add|Sonata No.2|Chopin|B Minor',
    'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
    'Add|Fur Elise|Beethoven|C# Minor',
    'Remove|Clair de Lune',
    'ChangeKey|Moonlight Sonata|C# Major',
    'Stop'
]);
console.log('===');
pianist([
    '4',
    'Eine kleine Nachtmusik|Mozart|G Major',
    'La Campanella|Liszt|G# Minor',
    'The Marriage of Figaro|Mozart|G Major',
    'Hungarian Dance No.5|Brahms|G Minor',
    'Add|Spring|Vivaldi|E Major',
    'Remove|The Marriage of Figaro',
    'Remove|Turkish March',
    'ChangeKey|Spring|C Major',
    'Add|Nocturne|Chopin|C# Minor',
    'Stop'
]);