function extractText() {
    let liElements = Array.from(document.querySelectorAll('#items'));
    let textArea = document.getElementById('result'); 
    for (const li of liElements) {
        textArea.textContent += li.textContent + '\n'
    }
}