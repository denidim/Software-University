function getRect([x1, y1, x2, y2]) {
    x1 = Number(x1);
    y1 = Number(y1);
    x2 = Number(x2);
    y2 = Number(y2);
    let a = Math.abs(x1 - x2);
    let b = Math.abs(y1 - y2);

    console.log(a * b);
    console.log(2*(a + b));
}
getRect(['10', '50', '60', '20']);