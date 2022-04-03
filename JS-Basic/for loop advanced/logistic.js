function logistic(input) {
    let n = Number(input[0]);
    let load = Number(input[1]);
    let index = 2;

    let price = 0;
    let totalLoad = 0;
    let avgPrice = 0;
    let totalPrice = 0;
    let loadVan = 0;
    let loadLory = 0;
    let loadTrain = 0;
    let procentVan = 0;
    let procentLory = 0;
    let procentTrain = 0;

    for (let i = 1; i <= n; i++) {

        if (load <= 3) {
            price = load * 200;
            totalLoad += load;
            loadVan += load;
            totalPrice += price;
        }
        else if (load >= 4 && load <= 11) {
            price = load * 175;
            totalLoad += load;
            loadLory += load;
            totalPrice += price;
        }
        else if (load >= 12) {
            price = load * 120;
            totalLoad += load;
            loadTrain += load;
            totalPrice += price;
        }
        load = Number(input[index]);
        index++;
    }
    procentVan = loadVan / totalLoad * 100;
    procentLory = loadLory / totalLoad * 100;
    procentTrain = loadTrain / totalLoad * 100;
    avgPrice = totalPrice / totalLoad;

    console.log(avgPrice.toFixed(2));
    console.log(procentVan.toFixed(2) + '%');
    console.log(procentLory.toFixed(2) + '%');
    console.log(procentTrain.toFixed(2) + '%');
}

logistic(['4', '1', '5', '16', '3']);