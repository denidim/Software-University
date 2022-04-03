function tSeamAccount(arr) {
    let account = arr.shift().split(' ');
    
    for (let line of arr) {

        let tokens = line.split(' ');
        let command = tokens[0];
        let game = tokens[1];

        if (command === 'Install') {

            if (!account.includes(game)) {
                account.push(game);
            } else {
                break;
            }

        } else if (command === 'Uninstall') {

            if (account.includes(game)) {

                for (let i = 0; i < account.length; i++) {

                    if (account[i] === game) {

                        account.splice(i, 1);
                    }
                }
            } else {
                break;
            }
            
        } else if (command === 'Update') {

            if (account.includes(game)) {
                for (let i = 0; i < account.length; i++) {

                    if (account[i] === game) {

                        account.splice(i, 1);
                        account.push(game);
                        break;
                    }
                }
            } else {
                break;
            }

        } else if (command === 'Expansion') {
            let gameName = game.split('-');

            if (account.includes(gameName[0])) {

                for (let i = 0; i < account.length; i++) {
                    if (account[i] === gameName[0]) {

                        account.splice(i + 1, 0, gameName.join(':'));
                        break;
                    }
                }
            }
            else {
                break;
            }
        }
    }
    console.log(account.join(' '));
}


tSeamAccount(['CS WoW Diablo',
    'Install LoL',
    'Uninstall WoW',
    'Update Diablo',
    'Expansion CS-Go',
    'Play!']);

tSeamAccount(['CS WoW Diablo',
    'Uninstall XCOM',
    'Update PeshoGame',
    'Update WoW',
    'Expansion Civ-V',
    'Play!']);
