function biggestOf3Numbers(a, b, c) {
    let biggest = 0;

    if (a > b) {
        biggest = a;
    } else if(b > c){
        biggest = b;
    } else{
        biggest = c;
    }
    console.log(biggest);

}
biggestOf3Numbers(-2, 7, 3);
biggestOf3Numbers(130, 5, 99);
biggestOf3Numbers(43, 43.2, 43.1);