function searchNumber(collection, numbers) {
    let elementToCut = numbers[0];
    let elementToDel = numbers[1];
    let elementToFind = numbers[2];

    let newArr = collection.slice(0, elementToCut);
    newArr.splice(0, elementToDel);
    let counter = 0;
    let newArrL = newArr.length;

    for(let i = 0; i < newArrL; i++){
        if(newArr[i] === elementToFind){
counter++;
        }
    }

    console.log(`Number ${elementToFind} occurs ${counter} times.`);
}
searchNumber([5, 2, 3, 4, 1, 6],
    [5, 2, 3]);