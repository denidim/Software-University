function solve(array) {
    let board = {}

    let n = array.shift();
    for (let i = 0; i < n; i++) {
        let [assignee, taskId, title, taskStatus, points] = array.shift().split(':');
        points = Number(points);
        if (!board.hasOwnProperty(assignee)) {
            board[assignee] = [{ taskId, title, taskStatus, points }]
        } else {
            board[assignee].push({ taskId, title, taskStatus, points });
        }
    }
    for (const commands of array) {
        let command = commands.split(':').shift();
        if (command === 'Add New') {
            let splitted = commands.split(':');
            splitted.splice(0, 1)
            let name = splitted.shift();
            [taskId, title, taskStatus, points] = splitted;
            let newObj = { taskId, title, taskStatus, points };
            if (Object.keys(board).includes(name)) {
                board[name].push(newObj);
            } else {
                console.log(`Assignee ${name} does not exist on the board!`)
            }
        } else if (command === 'Change Status') {
            let splitted = commands.split(':');
            splitted.splice(0, 1);
            [assignee, taskId, taskStatus] = splitted;

            if (Object.keys(board).includes(assignee)) {
                let taskObjArray = Object.values(board[assignee]);

                if (taskObjArray.find(e => e.taskId === taskId)) {
                    taskObjArray.find(e => e.taskId === taskId).taskStatus = taskStatus;
                } else {
                    console.log(`Task with ID ${taskId} does not exist for ${assignee}!`)
                }
            } else {
                console.log(`Assignee ${assignee} does not exist on the board!`);
            }
        } else if (command === 'Remove Task') {
            let splitted = commands.split(':');
            splitted.splice(0, 1);
            [assignee, index] = splitted;
            if (Object.keys(board).includes(assignee)) {
                if (index < board[assignee].length) {
                    board[assignee].splice(index, 1)
                } else {
                    console.log('Index is out of range!')
                }
            } else {
                console.log(`Assignee ${assignee} does not exist on the board!`)
            }
        }
    }
    let toDo = 0;
    let inProgress = 0;
    let codeReview = 0;
    let donePoints = 0;
    for (const key in board) {
        let objArray = board[key];
        for (const element of objArray) {
            if (element.taskStatus === 'ToDo') {
                toDo += Number(element.points);
            }
            if (element.taskStatus === 'In Progress') {
                inProgress += Number(element.points);
            }
            if (element.taskStatus === 'Code Review') {
                codeReview += Number(element.points);
            }
            if (element.taskStatus === 'Done') {
                donePoints += Number(element.points);
            }
        }
    }
    console.log(`ToDo: ${toDo}pts`)
    console.log(`In Progress: ${inProgress}pts`)
    console.log(`Code Review: ${codeReview}pts`)
    console.log(`Done Points: ${donePoints}pts`)

    if (donePoints >= inProgress + toDo + codeReview) {
        console.log('Sprint was successful!')
    } else {
        console.log('Sprint was unsuccessful...')
    }
}

solve([

    '4',

    'Kiril:BOP-1213:Fix Typo:Done:1',

    'Peter:BOP-1214:New Products Page:In Progress:2',

    'Mariya:BOP-1215:Setup Routing:ToDo:8',

    'Georgi:BOP-1216:Add Business Card:Code Review:3',

    'Add New:Sam:BOP-1237:Testing Home Page:Done:3',

    'Change Status:Georgi:BOP-1216:Done',

    'Change Status:Will:BOP-1212:In Progress',

    'Remove Task:Georgi:3',

    'Change Status:Mariya:BOP-1215:Done',

]);

solve([

    '5',

    'Kiril:BOP-1209:Fix Minor Bug:ToDo:3',

    'Mariya:BOP-1210:Fix Major Bug:In Progress:3',

    'Peter:BOP-1211:POC:Code Review:5',

    'Georgi:BOP-1212:Investigation Task:Done:2',

    'Mariya:BOP-1213:New Account Page:In Progress:13',

    'Add New:Kiril:BOP-1217:Add Info Page:In Progress:5',

    'Change Status:Peter:BOP-1290:ToDo',

    'Remove Task:Mariya:1',

    'Remove Task:Joro:1',

]);