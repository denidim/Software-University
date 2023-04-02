function Songs(input) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        };
    }

    let num = input.shift();
    let type = input.pop();
    let songs = [];

    for (const element of input) {
        let splitted = element.split('_');
        let typeList = splitted[0];
        let name = splitted[1];
        let time = splitted[2];

        if (type === 'all' || type === typeList) {
            songs.push(new Song(typeList, name, time));
        }
    }

    for (const song of songs) {
        console.log(song.name);
    }

}

Songs([4,

    'favourite_DownTown_3:14',

    'listenLater_Andalouse_3:24',

    'favourite_In To The Night_3:58',

    'favourite_Live It Up_3:48',

    'listenLater'])