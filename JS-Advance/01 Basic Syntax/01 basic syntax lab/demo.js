function solve(name) {
  if(name === 'England' || name === 'USA'){
    console.log('English');
  } else if(name === 'Spain' || name === 'Argentina' || name === 'Mexico'){
    console.log('Spanish');
  }else{
    console.log('unknown');
  }
}
solve('USA');
solve('Germany');

