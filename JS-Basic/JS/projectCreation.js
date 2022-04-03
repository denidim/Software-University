function projectCreation([arg1, arg2]){
    let name = arg1;
    let projects = parseInt(arg2);
    let hours = projects * 3;
    console.log(`The architect ${name} will need ${hours} hours to complete ${projects} project/s.`);
}
projectCreation(['Ivan', '4'])
