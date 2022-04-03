function sortArray(list) {
/*
    list.sort((a, b) => {
    let firstCriteria = a.length - b.length;
    let secondCriteria = a.localeCompare(b);

    return firstCriteria || secondCriteria;
    });
*/
list.sort((a, b) => a.length - b.length || a.localeCompare(b));
    console.log(list.join('\n'));
}
sortArray(["alpha", "beta", "gamma"]);
sortArray(["Isacc", "Theodor", "Jack", "Harrison", "George"]);