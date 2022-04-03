function bonusScoreSystem(list) {

    let studentCount = Number(list.shift());
    let lecturesCount = Number(list.shift());
    let initialBonus = Number(list.shift());
    let students = list.map(x => Number(x));

    students = students.sort((a, b) => b - a);
    let maxLectures = students.shift();
    let maxBonus = maxLectures / lecturesCount * (5 + initialBonus);
    maxBonus = Math.ceil(maxBonus);
   
    if(maxBonus > 0){
    console.log(`Max Bonus: ${maxBonus}.`);
    console.log(`The student has attended ${maxLectures} lectures.`);
    } else{
        console.log(`Max Bonus: 0.`);
    console.log(`The student has attended 0 lectures.`);
    }
}
bonusScoreSystem([
        '5',  '25', '30',
        '12', '19', '24',
        '16', '20'
      ]);

bonusScoreSystem([
    '10', '30', '14', '8',
    '23', '27', '28', '15',
    '17', '25', '26', '5',
    '18'
  ]);