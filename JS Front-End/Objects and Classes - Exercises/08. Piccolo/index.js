function parkingLot(carArr) {
    let cars = [];
  
    for (let i = 0; i < carArr.length; i++) 
    {
      let [direction, numPlate] = carArr[i].split(", ");
  
      if (direction === "IN") {
        cars.push(numPlate);
      } else if (direction === "OUT") {
        const index = cars.indexOf(numPlate);
        if (index !== -1) {
          cars.splice(index, 1);
        }
      }
    }
  
    if (cars.length !== 0) {
      cars.sort();
      cars.forEach((car) => {
        console.log(car);
      });
    } else {
      console.log("Parking Lot is Empty");
    }
  }
  
  parkingLot([
    "IN, CA2844AA",
    "IN, CA1234TA",
    "OUT, CA2844AA",
    "IN, CA9999TT",
    "IN, CA2866HI",
    "OUT, CA1234TA",
    "IN, CA2844AA",
    "OUT, CA2866HI",
    "IN, CA9876HH",
    "IN, CA2822UU",
  ]);
  