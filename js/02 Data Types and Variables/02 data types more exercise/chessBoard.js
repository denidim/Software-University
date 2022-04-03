function chessBoard(n) {
    let result = '<div class="chessboard">\n';
    let colour = 'black';

    for (i = 0; i < n; i++) {
        result += '  <div>\n';

        if (n % 2 === 0) {
            if (colour === 'black') {
                colour = 'white';
            } else {
                colour = 'black';
            }
        }
        if (i === 0) {
            colour = 'black'
        }
        for (let j = 0; j < n; j++) {
            result += `    <span class="${colour}"></span>\n`;

            if (colour === 'black') {
                colour = 'white';
            } else {
                colour = 'black';
            }
        }
        result += '  </div>\n';
    }
    result += '</div>\n';
    console.log(result);
}
chessBoard(3);