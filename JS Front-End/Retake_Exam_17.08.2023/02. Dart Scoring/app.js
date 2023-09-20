window.addEventListener("load", solve);

function solve() {
    const nameInput = document.getElementById('player');
    const scoreInput = document.getElementById('score');
    const roundInput = document.getElementById('round');
    const addButton = document.getElementById('add-btn');
    const itemList = document.getElementById('sure-list');
    const scoreboardList = document.getElementById('scoreboard-list');
    const clearButton = document.querySelector('.btn.clear');
    const form = document.querySelector('.scoring-content');

    addButton.addEventListener('click', addItemToList);
    clearButton.addEventListener('click', clearScoreboard);

    function addItemToList() {
        const newName = nameInput.value;
        const newScore = parseInt(scoreInput.value);
        const newRound = parseInt(roundInput.value);
    
        if (newName !== '' && !isNaN(newScore) && !isNaN(newRound)) {
            const listItem = createListItem(newName, newScore, newRound);
            itemList.appendChild(listItem);
    
            clearInputs();
            addButton.disabled = true;
        } else {
            // Handle the case where something is empty
            console.log("Please fill in all the fields.");
            // Or display an error message to the user
        }
    }
    

    function createListItem(name, score, round) {
        const listItem = document.createElement('li');
        listItem.className = 'dart-item';

        const article = document.createElement('article');
        const nameParagraph = document.createElement('p');
        nameParagraph.textContent = name;
        const scoreParagraph = document.createElement('p');
        scoreParagraph.textContent = `Score: ${score}`;
        const roundParagraph = document.createElement('p');
        roundParagraph.textContent = `Round: ${round}`;

        article.appendChild(nameParagraph);
        article.appendChild(scoreParagraph);
        article.appendChild(roundParagraph);

        const editButton = document.createElement('button');
        editButton.className = 'btn edit';
        editButton.textContent = 'edit';
        editButton.addEventListener('click', editItem);

        const okButton = document.createElement('button');
        okButton.className = 'btn ok';
        okButton.textContent = 'ok';
        okButton.addEventListener('click', moveToScoreboard);

        listItem.appendChild(article);
        listItem.appendChild(editButton);
        listItem.appendChild(okButton);

        return listItem;
    }

    function editItem(event) {
        const listItem = event.target.closest('.dart-item');
        const article = listItem.querySelector('article');
        const name = article.querySelector('p').textContent;
        const score = article.querySelector('p:nth-child(2)').textContent.split(' ')[1];
        const round = article.querySelector('p:nth-child(3)').textContent.split(' ')[1];

        nameInput.value = name;
        scoreInput.value = score;
        roundInput.value = round;

        itemList.removeChild(listItem);

        addButton.disabled = false;
    }

    function moveToScoreboard(event) {
        const listItem = event.target.closest('.dart-item');
        const article = listItem.querySelector('article');
        const name = article.querySelector('p').textContent;
        const score = article.querySelector('p:nth-child(2)').textContent.split(' ')[1];
        const round = article.querySelector('p:nth-child(3)').textContent.split(' ')[1];

        const newItem = createScoreboardItem(name, score, round);
        scoreboardList.appendChild(newItem);

        clearInputs();
        itemList.removeChild(listItem);
        addButton.disabled = false;
    }

    function createScoreboardItem(name, score, round) {
        const listItem = document.createElement('li');
        listItem.className = 'dart-item';

        const article = document.createElement('article');
        const nameParagraph = document.createElement('p');
        nameParagraph.textContent = name;
        const scoreParagraph = document.createElement('p');
        scoreParagraph.textContent = `Score: ${score}`;
        const roundParagraph = document.createElement('p');
        roundParagraph.textContent = `Round: ${round}`;

        article.appendChild(nameParagraph);
        article.appendChild(scoreParagraph);
        article.appendChild(roundParagraph);

        listItem.appendChild(article);

        return listItem;
    }

    function clearInputs() {
        nameInput.value = '';
        scoreInput.value = '';
        roundInput.value = '';
    }

    function clearScoreboard() {
        while (scoreboardList.firstChild) {
            scoreboardList.removeChild(scoreboardList.firstChild);
        }

        location.reload();
    }

    form.addEventListener('click', function(event) {
        if (event.target.classList.contains('edit')) {
            editItem(event);
        } else if (event.target.classList.contains('ok')) {
            moveToScoreboard(event);
        }
    });
}