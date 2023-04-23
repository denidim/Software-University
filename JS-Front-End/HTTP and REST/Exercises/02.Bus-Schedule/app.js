function solve() {
    console.log('somthing')
    const spanInfo = document.querySelector('#info > span');
    const BASE_URL = 'http://localhost:3030/jsonstore/bus/schedule/';
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    let nextStopId = 'depot';
    let nextStopName = '';
    function depart() {
        departBtn.disabled = true;
        arriveBtn.disabled = false;
        fetch(`${BASE_URL}${nextStopId}`)
            .then((res) => res.json())
            .then((data) => {
                const { name, next } = data;
                spanInfo.textContent = `Next stop ${name}`;
                nextStopName = name;
                nextStopId = next;
            })
            .catch(() => {
                departBtn.disabled = true;
                arriveBtn.disabled = true;
                spanInfo.textContent = 'Error';
            })
    }

    async function arrive() {
        departBtn.disabled = false;
        arriveBtn.disabled = true;
        spanInfo.textContent = `Arriving at ${nextStopName}`;

    }

    return {
        depart,
        arrive
    };
}

let result = solve();