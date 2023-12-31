function checkDistance(x1, y1, x2, y2) {
    const distance1 = Math.sqrt(x1 * x1 + y1 * y1);
    const distance2 = Math.sqrt(x2 * x2 + y2 * y2);
    const distance3 = Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
  
    function isValid(distance) {
      return Number.isInteger(distance);
    }
  
    if (isValid(distance1)) {
      console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
      console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }
  
    if (isValid(distance2)) {
      console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
      console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }
  
    if (isValid(distance3)) {
      console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
      console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
  }

//checkDistance(3, 0, 0, 4);
checkDistance(2, 1, 1, 1);