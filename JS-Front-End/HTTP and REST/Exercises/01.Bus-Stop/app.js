function getInfo() {
    const stopId = document.getElementById('stopId').value;
    const divStopNameContainer = document.getElementById('stopName');
    const ulBusesContainer = document.getElementById('buses');
    const BASE_URL = 'http://localhost:3030/jsonstore/bus/businfo/';

    ulBusesContainer.innerHTML = '';

    fetch(`${BASE_URL}${stopId}`)
        .then((res) => res.json())
        .then((data) => {
            const { name, buses } = data;
            divStopNameContainer.textContent = name;
            for (const busId in buses) {
                const li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${buses[busId]} minutes`;
                ulBusesContainer.appendChild(li);
            }
        })
        .catch(() => {
            divStopNameContainer.textContent = 'Error';
        })
}