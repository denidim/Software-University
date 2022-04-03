function loadingBar(n) {
    let loading = '';

    if (n === 100) {
        console.log('100% Complete!');
        console.log('[%%%%%%%%%%]');
    } else {

        for (let i = 0; i < (n / 10); i++) {
            loading += '%';
        }
        for (let j = n / 10; j < 10; j++) {
            loading += '.'
        }
        console.log(`${n}% [${loading}]`);
        console.log('Still loading...');
    }

}
loadingBar(30);
loadingBar(50);
loadingBar(100);