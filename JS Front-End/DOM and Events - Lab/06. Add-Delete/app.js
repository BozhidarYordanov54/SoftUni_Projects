  function addItem() {
    var newItemText = document.getElementById("newItemText").value.trim();
    if (newItemText === "") {
      return;
    }
  
    var itemsList = document.getElementById("items");
  
    var listItem = document.createElement("li");
    listItem.textContent = newItemText;
  
    var deleteLink = document.createElement("a");
    deleteLink.href = "#";
    deleteLink.textContent = "[Delete]";
    deleteLink.addEventListener("click", deleteItem);
  
    listItem.appendChild(deleteLink);
    itemsList.appendChild(listItem);
  
    document.getElementById("newItemText").value = "";
  }
  