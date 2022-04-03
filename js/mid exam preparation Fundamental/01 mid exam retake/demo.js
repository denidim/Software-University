if (ppl != 0) {
    console.log(`There isn't enough space! ${ppl} people in a queue!`);
    console.log(wagons.join(' '));
} else {
    for (let wagon of wagons) {
        
        if (wagon === 4) {
            wagonSpaceCount++;
        }
    }
    if (wagonSpaceCount != wagons.length) {
        console.log("The lift has empty spots!");
        console.log(`${wagons.join(' ')}`)
    } else {
        console.log(`${wagons.join(' ')}`)
    }
}
