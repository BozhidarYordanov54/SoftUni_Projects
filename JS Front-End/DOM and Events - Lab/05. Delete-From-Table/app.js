function deleteByEmail() {
    var emailInput = document.querySelector('input[name="email"]');
    var email = emailInput.value.trim();
  
    var table = document.getElementById("customers");
    if (!table) {
      console.error("Table element with id 'customers' not found.");
      return;
    }
  
    var rows = table.getElementsByTagName("tr");
    var found = false;
  
    for (var i = 0; i < rows.length; i++) {
      var row = rows[i];
      var cells = row.getElementsByTagName("td");
  
      if (cells.length >= 2) {
        var emailCell = cells[1];
  
        if (emailCell.textContent === email) {
          row.remove();
          found = true;
          break;
        }
      }
    }
  
    var result = document.getElementById("result");
    if (!result) {
      console.error("Result element with id 'result' not found.");
      return;
    }
  
    result.textContent = found ? "Deleted." : "Not found.";
  }
  