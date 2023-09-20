function addItem() {
    let list = document.getElementById('items');
    let inputField = document.getElementById('newItemText');

    let text = inputField.value;
    
    let listItem = document.createElement('li');
    listItem.textContent = text;

    list.appendChild(listItem);
}