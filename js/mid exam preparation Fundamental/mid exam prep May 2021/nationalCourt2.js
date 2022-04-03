function nationalCourt(input) {
    let [e1, e2, e3, people] = input.map(Number);
    if (people == 0) {
        console.log('Time needed: 0h.');
        return;
    }

    let efficiency = e1 + e2 + e3;
    let required = Math.ceil(people / efficiency);
    let pause = Math.floor(required / 3);

    if (required % 3 == 0) {
        pause -= 1;
    }

    console.log(`Time needed: ${required + pause}h.`);
}
nationalCourt(['5', '6', '4', '20']);
nationalCourt(['1', '2', '3', '45']);