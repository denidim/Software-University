function PrintMeetings(arr) {
    let meetings = {};

    for (const key of arr) {
        let meeting = key.split(' ');
        if (meetings.hasOwnProperty(meeting[0])) {
            console.log(`Conflict on ${meeting[0]}!`)
        } else {
            console.log(`Scheduled for ${meeting[0]}`)
            meetings[meeting[0]] = meeting[1]
        }
    }

    for (const key in meetings) {
        console.log(`${key} -> ${meetings[key]}`)
    }
}

PrintMeetings(['Friday Bob', 'Saturday Ted', 'Monday Bill', 'Monday John', 'Wednesday George']);