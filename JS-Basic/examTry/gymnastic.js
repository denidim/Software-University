function gymnastic(input) {

    let country = input[0];
    let type = input[1];

    let score = 0;

    let totalScore = 20;
    let scoreLack = 0;
    let procent = 0;


    if (country === 'Bulgaria') {

        switch (type) {
            case 'ribbon': score = 9.600 + 9.400; break;
            case 'hoop': score = 9.550 + 9.750; break;
            case 'rope': score = 9.500 + 9.400; break;
        }

    }

    if (country === 'Russia') {

        switch (type) {
            case 'ribbon': score = 9.100 + 9.400; break;
            case 'hoop': score = 9.300 + 9.800; break;
            case 'rope': score = 9.600 + 9.000; break;


        }
    }
    if (country === 'Italy') {

        switch (type) {
            case 'ribbon': score = 9.200 + 9.500; break;
            case 'hoop': score = 9.450 + 9.350; break;
            case 'rope': score = 9.700 + 9.150; break;
        }
    }
    scoreLack = totalScore - score;
    procent = (scoreLack / totalScore) * 100;

    console.log(`The team of ${country} get ${score.toFixed(3)} on ${type}.`);
    console.log(`${procent.toFixed(2)}%`);

}

gymnastic(["Bulgaria", "ribbon"]);