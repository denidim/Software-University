function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/messenger';
    const btnSubmit = document.getElementById('submit');
    const btnRefresh = document.getElementById('refresh');
    const inputAuthor = Array.from(document.querySelectorAll('#controls > div> input'))[0];
    const inputContent = Array.from(document.querySelectorAll('#controls > div> input'))[1];
    const textArea = document.getElementById('messages');

    btnSubmit.addEventListener('click', () => {
        const authorName = inputAuthor.value;
        const msgText = inputContent.value;
        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify({ author: authorName, content: msgText })
        }
        fetch(BASE_URL, httpHeaders);
        inputAuthor.value = '';
        inputContent.value = '';
    });

    btnRefresh.addEventListener('click', () => {
        textArea.textContent = '';
        let result = '';
        fetch(BASE_URL)
            .then((res) => res.json())
            .then((data) => {
                for (const key in data) {               
                  result += `${data[key].author}: ${data[key].content}\n`;
                }
              textArea.textContent = result.trimEnd();            
            })
    });
}

attachEvents();