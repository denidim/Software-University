function metricConvertor(input) {

    let size = parseFloat(input[0]);
    let sourceMertic = input[1].toLowerCase();
    let destMetric = input[2].toLowerCase();

    if (sourceMertic === 'mm') {
        size = size / 1000;

    }
    else if (sourceMertic === 'cm') {
        size = size / 100;

    }
    else if (sourceMertic === 'm') {
        size = size / 1;
    }

    if (destMetric === 'mm') {
        size = size * 1000;

    }
    else if (destMetric === 'cm') {
        size = size * 100;

    }
    else if (destMetric === 'm') {
        size = size * 1;
    }

    console.log(size.toFixed(3));

}
metricConvertor(["150", "m", "cm"]);
