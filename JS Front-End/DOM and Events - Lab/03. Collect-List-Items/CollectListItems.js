function extractText() {
    const items = document.getElementsByTagName('li');
    let resultArea = document.getElementById('result');

    for(let i = 0; i < items.length; i++)
    {
        let listItem = items[i];
        var listItemText = listItem.textContent || listItem.innerText;

        resultArea.value += listItemText + '\n';
    }
}