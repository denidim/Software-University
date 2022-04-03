function hospital(input) {
    let n = Number(input[0]);
    let patients = Number(input[1]);
    let treated = 0;
    let untreated = 0
    let doctors = 7;
    let index = 2;

    for (let i = 1; i <= n; i++) {
        if (i % 3 === 0) {
            if (untreated > treated) {
                doctors++;
            }

        }
        if (patients <= doctors) {
            treated += patients;
        }
        else {
            treated += doctors;
            untreated += patients - doctors;
        }

        patients = Number(input[index]);
        index++;
    }
    console.log(`Treated patients: ${treated}.`);
    console.log(`Untreated patients: ${untreated}.`);
}

hospital(['6', '25', '25', '25', '25', '25', '2']);
