function bonusScoreSystem(list) {

    let studentCount = Number(list.shift());
    let lecturesCount = Number(list.shift());
    let initialBonus = Number(list.shift());
    let students = list.map(x => Number(x));
    let maxBonus = 0;
    let maxLectures = 0;

    for(let i = 0; i < studentCount; i++){
        let currentLectureCount = students[i];
        let currentBonus = currentLectureCount / lecturesCount * (5 + initialBonus);
        if(currentBonus > maxBonus){
            maxBonus = currentBonus;
            maxLectures = currentLectureCount;
        }
    }
    console.log(`Max Bonus: ${Math.ceil(maxBonus)}.`);
    console.log(`The student has attended ${maxLectures} lectures. `);
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