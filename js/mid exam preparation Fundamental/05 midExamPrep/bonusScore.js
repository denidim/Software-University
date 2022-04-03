function bonusScore(list) {
  let studentsCount = Number(list.shift());
  let lecturesCount = Number(list.shift());
  let additBonus = Number(list.shift());

  let maxLectures = 0;
  let maxBonus = 0;
  for (let i = 0; i <= studentsCount; i++) {
    let currAttendance = Number(list[i]);
    let totalBonus = (currAttendance / lecturesCount * (5 + additBonus));

    if (currAttendance > maxLectures) {
      maxLectures = currAttendance;
    }
    if (totalBonus > maxBonus) {
      maxBonus = totalBonus;
    }
  }

  if (maxBonus > 0) {
    console.log(`Max Bonus: ${Math.ceil(maxBonus)}.`);
    console.log(`The student has attended ${maxLectures} lectures.`);
  } else {
    console.log('Max Bonus: 0.');
    console.log('The student has attended 0 lectures.');
  }
}

bonusScore(["5", "25", "30", "12", "19", "24", "16", "20"]);

bonusScore(["10", "30", "14", "8", "23", "27", "28", "15", "17", "25", "26", "5", "18"]);
