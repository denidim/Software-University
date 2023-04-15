function PrintMovies(movies) {
    let objArr = [];
    for (const item of movies) {
        if (item.includes('addMovie')) {
            let name = item.split(' ').splice(1).join(' ');
            let moviesObj = { name: name };
            objArr.push(moviesObj);
        } else if (item.includes('directedBy')) {
            let name = item.split(' directedBy ')[0];
            let director = item.split(' directedBy ')[1];
            let movie = objArr.find((moviesObj) => moviesObj.name === name);
            if (movie) {
                movie.director = director;
            }
        } else if (item.includes('onDate')) {
            let name = item.split(' onDate ')[0];
            let date = item.split(' onDate ')[1];
            let movie = objArr.find((moviesObj) => moviesObj.name === name);
            if (movie) {
                movie.date = date;
            }
        }
    }

    let filtered = objArr.filter((item)=>item.hasOwnProperty('name') 
    && item.hasOwnProperty('director') 
    && item.hasOwnProperty('date'))
    .forEach(m=>console.log(JSON.stringify(m)));

    // for (const item of objArr) {
    //     if (item.hasOwnProperty('name') 
    //     && item.hasOwnProperty('director') 
    //     && item.hasOwnProperty('date')) {
    //         console.log(JSON.stringify(item));
    //     }
    // }
}

PrintMovies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]);

PrintMovies([

    'addMovie The Avengers',
    
    'addMovie Superman',
    
    'The Avengers directedBy Anthony Russo',
    
    'The Avengers onDate 30.07.2010',
    
    'Captain America onDate 30.07.2010',
    
    'Captain America directedBy Joe Russo'
    
    ])