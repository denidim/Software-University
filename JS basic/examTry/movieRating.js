function movieRat(input) {

    let index = 0;
    let movieNumber = Number(input[index]);
    index++;
    let movieName = input[index];
    index++;
    let movieRating = Number(input[index]);
    index++;
    let movieCouner = 0;

    let minRating = 0;
    let maxRating = 0;

    for(let i = 1; i <= movieNumber; i++){
        let currentMovie = movieName;
        let currrentRating += movieRating;

        if(currrentRating >= minRating){
            minRating =currrentRating;
        }
        movieCouner++
    }
    let avgRating = 

}
movieRat(['5', 'A Star is Born', '7.8', 'Creed 2', '7.3', 'Mary Poppins', '7.2', 'Vice', '7.2', 'Captain Marvel', '7.1']);