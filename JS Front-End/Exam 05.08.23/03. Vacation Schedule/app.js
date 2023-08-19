function solve() {
  const loadButton = document.querySelector('#load-vacations');
  const addButton = document.querySelector('#add-vacation');
  const editButton = document.querySelector('#editVacation');
  const listDiv = document.querySelector('#list');
  const nameInput = document.querySelector('#name');
  const daysInput = document.querySelector('#num-days');
  const dateInput = document.querySelector('#from-date');

  loadButton.addEventListener('click', loadVacations);

  addButton.addEventListener('click', addVacation);

  let selectedVacationId = null;
  let editMode = false;

  function loadVacations() {
    fetch('http://localhost:3030/jsonstore/tasks/')
      .then(response => response.json())
      .then(data => {
        listDiv.innerHTML = '';
        for (const id in data) {
          const vacation = data[id];
          const vacationDiv = createVacationDiv(id, vacation);
          listDiv.appendChild(vacationDiv);
        }
      })
      .catch(error => console.error('Error loading vacations:', error));
  }

  function createVacationDiv(id, vacation) {
    const vacationDiv = document.createElement('div');
    vacationDiv.className = 'container';
    vacationDiv.innerHTML = `
      <h2>${vacation.name}</h2>
      <h3>${vacation.date}</h3>
      <h3>${vacation.days}</h3>
      <button class="change-btn">Change</button>
      <button class="done-btn">Done</button>
    `;

    const changeButton = vacationDiv.querySelector('.change-btn');
    changeButton.addEventListener('click', () => editVacation(id, vacation));

    const doneButton = vacationDiv.querySelector('.done-btn');
    doneButton.addEventListener('click', () => deleteVacation(id));

    return vacationDiv;
  }

  async function addVacation() {
    if (editMode) {
      // Implement your edit logic here
    } else {
      const newVacation = {
        name: nameInput.value,
        days: Number(daysInput.value),
        date: dateInput.value,
      };

      try {
        const response = await fetch('http://localhost:3030/jsonstore/tasks/', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(newVacation),
        });

        if (response.ok) {
          nameInput.value = '';
          daysInput.value = '';
          dateInput.value = '';
          await loadVacations(); // Wait for data to be reloaded after adding
        } else {
          console.error('Failed to add vacation:', response.statusText);
        }
      } catch (error) {
        console.error('Error adding vacation:', error);
      }
    }
  }

  function editVacation(id, vacation) {
    selectedVacationId = id;
    editMode = true;

    nameInput.value = vacation.name;
    daysInput.value = vacation.days;
    dateInput.value = vacation.date;

    editButton.style.display = 'block';
    addButton.style.display = 'none';
  }

  function deleteVacation(id) {
    fetch(`http://localhost:3030/jsonstore/tasks/${id}`, {
      method: 'DELETE',
    })
      .then(() => loadVacations())
      .catch(error => console.error('Error deleting vacation:', error));
  }

  editButton.addEventListener('click', async () => {
    if (selectedVacationId) {
      // Implement your edit update logic here
    }
  });

  // Initial load
  loadVacations();
}
