function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/forecaster/locations/';
    const userInput = document.getElementById('location');
    const submitBtn = document.getElementById('submit');
    const forecastContainer = document.getElementById('forecast');
    const forecastContainerLable = document.querySelector('#current .label');
    const currentConditionsContainer = document.getElementById('current');
    const upcomingConditionsContainer = document.getElementById('upcoming');

    const weatherSymbols = {
        'Sunny': '&#x2600', // ☀
        "Partly sunny": '&#x26C5', // ⛅
        'Overcast': '&#x2601',// ☁
        'Rain': '&#x2614', // ☂
        'Degrees': '&#176' // °
    }

    submitBtn.addEventListener('click', getWeather);

    function getWeather(e) {
        fetch(BASE_URL)
            .then((res) => res.json())
            .then((data) => {
                let obj = data.find((element) =>
                    element.name.toLowerCase() === userInput.value.toLowerCase()
                );
                getLocations(obj);

            })
            .catch((error) => {
                forecastContainer.style.display = 'block';
                forecastContainerLable.textContent = 'Error';
                upcomingConditionsContainer.style.display = 'none';
            })
    }

    function getLocations(obj) {
        let { _name, code } = obj;

        currentConditionsContainer.innerHTML = '';
        upcomingConditionsContainer.innerHTML = '';
        forecastContainer.style.display = 'block';

        getCurrentConditions(code);
        getThreeDayForecast(code);
    }

    function getCurrentConditions(code) {
        const CURRENT_WEATHER_URL = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
        fetch(CURRENT_WEATHER_URL)
            .then((res) => res.json())
            .then((data) => {

                let { name, forecast } = data;
                let { low, high, condition } = forecast;

                let divForecast = createElement('div', '', false, currentConditionsContainer, '', ['forecasts']);
                createElement('span', weatherSymbols[condition], true, divForecast, '', ['condition', 'symbol']);
                let span = createElement('span', '', false, divForecast, '', ['condition']);
                createElement('span', name, false, span, '', ['forecast-data']);
                createElement('span', `${low}${weatherSymbols['Degrees']}/${high}${weatherSymbols['Degrees']}`, true, span, '', ['forecast-data']);
                createElement('span', condition, false, span, '', ['forecast-data']);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    function getThreeDayForecast(code) {
        const UPCOMING_WEATHER_URL = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
        fetch(UPCOMING_WEATHER_URL)
            .then((res) => res.json())
            .then((data) => {

                let divForecastInfo = createElement('div', '', false, upcomingConditionsContainer, '', ['forecast-info']);

                let { name, forecast } = data;

                for (const item of forecast) {
                    let { low, high, condition } = item;

                    let span = createElement('span', '', false, divForecastInfo, '', ['upcoming']);

                    createElement('span', weatherSymbols[condition], true, span, '', ['symbol']);
                    createElement('span', `${low}${weatherSymbols['Degrees']}/${high}${weatherSymbols['Degrees']}`, true, span, '', ['forecast-data']);
                    createElement('span', condition, true, span, '', ['forecast-data']);
                }
            })
            .catch((error) => {
                console.log(error);
            })
    }

    function createElement(type, contentOrValue, useInnerHTML, parentNode, id, classes, attributes) {
        const htmlElement = document.createElement(type);
        if (contentOrValue && useInnerHTML) {
            htmlElement.innerHTML = contentOrValue;
        }
        else {
            if (contentOrValue && type === 'input') {
                htmlElement.value = contentOrValue;
            }
            if (contentOrValue && type !== 'input') {
                htmlElement.textContent = contentOrValue;
            }
        }
        if (id) {
            htmlElement.id = id;
        }
        if (classes) {
            htmlElement.classList.add(...classes);
        }
        if (attributes) {
            for (const key in attributes) {
                htmlElement.setAttribute(key, attributes[key]);
            }
        }
        if (parentNode) {
            parentNode.appendChild(htmlElement);
        }

        return htmlElement;
    }

}

attachEvents();