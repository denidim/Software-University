function solve() {
  let [generate, buy] = Array.from(document.querySelectorAll('button'));
  let [json, output] = Array.from(document.querySelectorAll('textarea'));
  let tbody = document.querySelector('.table > tbody');

  generate.addEventListener('click', clickHandler)
  buy.addEventListener('click', buyClickHandler)

  function clickHandler(e) {
    const data = JSON.parse(json.value);

    for (const { img, name, price, decFactor } of data) {
      let tableRow = createElement('tr', '', tbody);
      let firstTd = createElement('td', '', tableRow);
      createElement('img', '', firstTd, '', '', { src: img });
      let secondTd = createElement('td', '', tableRow);
      createElement('p', name, secondTd);
      let thirdTd = createElement('td', '', tableRow);
      createElement('p', price, thirdTd);
      let forthTd = createElement('td', '', tableRow);
      createElement('p', decFactor, forthTd);
      let fifthTd = createElement('td', '', tableRow);
      createElement('input', '', fifthTd, '', '', { type: 'checkbox' })
    }
  }

  function buyClickHandler(e) {
    let allChecked = Array.from(document.querySelectorAll('tbody tr input:checked'));

    let boughtItems = [];
    let totalPrice = 0;
    let totalDecFactor = 0;

    for (const input of allChecked) {
      let tr = input.parentElement.parentElement;
      let [_first, second, third, fourth] = Array.from(tr.children);
      let item = second.children[0].textContent;
      boughtItems.push(item);
      let currPrice = Number(third.children[0].textContent);
      totalPrice += currPrice;
      let currDecFactor = Number(fourth.children[0].textContent);
      totalDecFactor += currDecFactor;
    }
    output.value = 'Bought furniture: ' + boughtItems.join(', ') + '\n' +
      'Total price: ' + totalPrice.toFixed(2) + '\n' +
      'Average decoration factor: ' + totalDecFactor / allChecked.length;
  }
  
  function createElement(type, content, parentNode, id, classes, attributes) {
    const htmlElement = document.createElement(type);
    if (content && type !== 'input') {
      htmlElement.textContent = content;
    }
    if (content && type === 'input') {
      htmlElement.input = input;
    }
    if (content && type !== 'input' && type === 'textarea') {
      htmlElement.value = content;
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

