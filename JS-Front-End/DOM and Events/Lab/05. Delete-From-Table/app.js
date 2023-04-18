function deleteByEmail() {

    let result = document.getElementById('result');

    let inputText = document.querySelector('label > input[name="email"]');

    let emails = Array.from(document
        .querySelectorAll('table > tbody > tr > :nth-child(2)'));

        console.log(emails);
    let foundElement = emails.find((e) => e.textContent === inputText.value);

    if (foundElement) {

        foundElement.parentElement.remove();

        result.textContent = 'Deleted.';

        inputText.value = '';

    } else {

        result.textContent = 'Not found.'

        inputText.value = '';
    }
}