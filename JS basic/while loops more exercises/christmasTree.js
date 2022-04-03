function christmasTree(input) {
    let n = Number(input[0]);

    
    for(let i = 0; i <= n; i++){
        console.log(" ".repeat(n + 2) + "| ".repeat(n - 1));
        console.log("* ".repeat(n - i) + "|");
        for(let j = n; j > n; j--){
            
            console.log(" *".repeat(n - 1));

        }

    }

}
christmasTree([2])