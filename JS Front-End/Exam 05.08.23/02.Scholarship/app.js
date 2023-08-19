function solve() {
  const studentInput = document.getElementById("student");
  const universityInput = document.getElementById("university");
  const scoreInput = document.getElementById("score");
  const previewList = document.getElementById("preview-list");
  const candidatesList = document.getElementById("candidates-list");
  const nextBtn = document.getElementById("next-btn");

  nextBtn.addEventListener("click", () => {
    const student = studentInput.value.trim();
    const university = universityInput.value.trim();
    const score = scoreInput.value.trim();

    if (student !== "" && university !== "" && score !== "") {
      const previewItem = createPreviewItem(student, university, score);
      previewList.appendChild(previewItem);

      studentInput.value = "";
      universityInput.value = "";
      scoreInput.value = "";

      nextBtn.disabled = true;
    }
  });

  previewList.addEventListener("click", (event) => {
    const target = event.target;

    if (target.tagName === "BUTTON") {
      const previewItem = target.closest(".application");
      if (previewItem) {
        if (target.classList.contains("edit")) {
          const article = previewItem.querySelector("article");
          const student = article.querySelector("h4").textContent;
          const university = article.querySelector("p:nth-child(2)").textContent.replace("University: ", "");
          const score = article.querySelector("p:nth-child(3)").textContent.replace("Score: ", "");

          studentInput.value = student;
          universityInput.value = university;
          scoreInput.value = score;

          previewList.removeChild(previewItem);
          nextBtn.disabled = false;
        } else if (target.classList.contains("apply")) {
          const clonedItem = previewItem.cloneNode(true);
          const editButton = clonedItem.querySelector(".edit");
          const applyButton = clonedItem.querySelector(".apply");
          if (editButton) {
            editButton.remove();
          }
          if (applyButton) {
            applyButton.remove();
          }
          candidatesList.appendChild(clonedItem);
          previewList.removeChild(previewItem);
          nextBtn.disabled = false; // Enable the next button after moving to candidates
        }
      }
    }
  });

  function createPreviewItem(student, university, score) {
    const previewItem = document.createElement("li");
    previewItem.classList.add("application");
    previewItem.innerHTML = `
      <article>
        <h4>${student}</h4>
        <p>University: ${university}</p>
        <p>Score: ${score}</p>
      </article>
      <button class="action-btn edit">edit</button>
      <button class="action-btn apply">apply</button>
    `;
    return previewItem;
  }
}

solve();
