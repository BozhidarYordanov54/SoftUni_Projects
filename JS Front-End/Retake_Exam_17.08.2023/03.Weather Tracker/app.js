const BASE_URL = 'http://localhost:3030/jsonstore/tasks';

const endpoints = {
    update: (id) => `${BASE_URL}/${id}`,
    delete: (id) => `${BASE_URL}/${id}`,
}
const locationElement = document.getElementById("location");
const temperatureElement = document.getElementById("temperature");
const dateElement = document.getElementById("date");

const list = document.getElementById('list');

const addBtn = document.getElementById("add-weather");
const editBtn = document.getElementById("edit-weather");
const loadBtn = document.getElementById("load-history");

function attachEvents() {
    loadBtn.addEventListener('click', loadBoardEventHandler);
    addBtn.addEventListener('click', (ev) => createTaskEventHandler(ev));
}

function getIdByName(task) {
    return fetch(BASE_URL)
        .then(res => res.json())
        .then(res => Object.entries(res).find(e => e[1].name == task)[1]._id)
}

async function loadBoardEventHandler() {
    clearAllSections();
    try {
        const res = await fetch(BASE_URL);
        const allTasks = await res.json();
        Object.values(allTasks)
            .forEach((task) => {
                list.innerHTML += `
                <div class="container">
                    <h2>${task.location}</h2>
                    <h3>${task.temperature}</h3>
                    <h3>${task.date}</h3>
                    <button class="change-btn">Change</button>
                    <button class="done-btn">Done</button>
                </div>`
                document.querySelector('.change-btn').addEventListener('click', (ev) => updateCourse(ev));
                document.querySelector('.done-btn').addEventListener('click', (ev) => deleteCourse(ev));
            })
    } catch (err) {
        console.error(err);
    }
}

function createTaskEventHandler(ev) {
    clearAllSections();

    ev.preventDefault();
    if(locationElement.value != '' && dateElement.value != '' && temperatureElement.value != '') {

    }
    const headers = {
        method: 'POST',
        body: JSON.stringify({
            name: locationElement.value,
            temperature: temperatureElement.value,
            date: dateElement.value,
        })
    };

    fetch(BASE_URL, headers)
        .then(loadBoardEventHandler)
        .catch(console.error);

    clearAllInputs();
}

async function updateCourse(ev) {
    ev.preventDefault();
    addBtn.disabled = true;
    editBtn.disabled = false;
    const name = article.querySelector('h2').textContent;
    const score = parseInt(article.querySelector('h3:nth-child(1)').textContent.split(' ')[1]);
    const round = parseInt(article.querySelector('h3:nth-child(2)').textContent.split(' ')[1]);

    nameInput.value = name;
    scoreInput.value = score;
    roundInput.value = round;

    itemList.removeChild(listItem);

    addButton.disabled = false;
   

    editCourse(location.textContent);
}

function editCourse(task) {
    editBtn.addEventListener('click', (e) => {
        e.preventDefault();
        const data = { location: locationElement.value, temperature: dateElement.value, date: temperatureElement.value};
        getIdByName(task)
            .then((id) => fetch(endpoints.update(id), {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    name: data.location,
                    days: data.temperature,
                    date: data.date,
                    _id: id
                })
            }))
            .then(() => {
                locationElement.value = '';
                dateElement.value = '';
                temperatureElement.value = '';
            })
            .then(loadBoardEventHandler);
            addBtn.disabled = false;
            editBtn.disabled = true;
    })
    
}

function deleteCourse (ev) {
    const tr = ev.target.parentElement;
    const task = Array.from(tr.children)[0];

    getIdByName(task.textContent)
        .then((id) => fetch(endpoints.delete(id), {
            method: 'DELETE',
            headers: { 'content-type': 'application/json' }
        }))
        .then(loadBoardEventHandler);
}

function clearAllSections() {
    document.getElementById('list').innerHTML = '';
}

function clearAllInputs() {
    locationElement.value = '';
    dateElement.value = '';
    temperatureElement.value = '';
}

attachEvents();
