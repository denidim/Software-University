function lockedProfile() {

    let buttons = Array.from(document.getElementsByTagName('button'));

    for (const button of buttons) {

        button.addEventListener('click', clickHandler)

        function clickHandler(e) {

            let lock = button.parentElement.querySelector('[value="lock"]');
            if (!lock.checked) {

                let hiddenDiv = button.parentElement.getElementsByTagName('div')[0];

                if (button.textContent === 'Show more') {

                    button.textContent = 'Hide it'

                    hiddenDiv.style.display = 'block'

                } else {

                    button.textContent = 'Show more'

                    hiddenDiv.style.display = 'none'
                }
            }
        }
    }
}