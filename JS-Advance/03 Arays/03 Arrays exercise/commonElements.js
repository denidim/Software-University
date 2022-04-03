function commonElements(firstList, secondList) {

    for(i = 0; i < firstList.length; i++){
        let firstListEl = firstList[i];

        for(let j = 0; j < secondList.length; j++){
            let secondListEl = secondList[j];

            if(firstListEl === secondListEl){
                console.log(firstListEl);
            }
        }
    }
}
commonElements(['Hey', 'hello', 2, 4, 'Peter', 'e'], ['Petar', 10, 'hey', 4, 'hello', '2']);

commonElements(['S', 'o', 'f', 't', 'U', 'n', 'i', ' '], ['s', 'o', 'c', 'i', 'a', 'l']);