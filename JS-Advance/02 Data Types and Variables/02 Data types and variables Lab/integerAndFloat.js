function integerAndFloat(a, b, c) {
    let sum = a + b + c;
    let rounded = Math.round(sum);
   if ( sum === rounded ){
       console.log(`${sum} - Integer `);
   } else {
       console.log(`${sum} - Float`);
   }
}
integerAndFloat(9, 100, 1.1);