let processOdd = n => n
 .filter((x, i) => i % 2 !== 0)
 .map(x => x * 2)
 .reverse()
 .join(' ');