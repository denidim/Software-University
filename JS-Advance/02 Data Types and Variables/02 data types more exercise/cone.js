function cone(r, h) {
    let volume = (Math.PI * (r ** 2) * h) / 3;
    let s = Math.sqrt((h * h) + (r * r));
    let area = (Math.PI * r * (r + s));
    console.log('volume = ' + volume.toFixed(4));
    console.log('area = ' + area.toFixed(4));

    
}
cone(3, 5);
cone(3.3, 7.8);