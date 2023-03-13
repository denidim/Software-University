function loadingBar(num) {
    if(num === 100){
        console.log('100% Complete!');
        console.log(`[${'%'.repeat(10)}]`);
    }else{
        console.log(`${num}% [${'%'.repeat(num/10)}${'.'.repeat(10-(num/10))}]`)
        console.log('Still loading...')
    }
}

loadingBar(30)
loadingBar(50)
loadingBar(100)
