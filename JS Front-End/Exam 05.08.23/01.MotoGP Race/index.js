function race(input) {
    let riders = [];
    
    function findRiderIndex(riderName) {
        return riders.findIndex(rider => rider.name === riderName);
    }
    
    function swapRiders(rider1Index, rider2Index) {
        const temp = riders[rider1Index];
        riders[rider1Index] = riders[rider2Index];
        riders[rider2Index] = temp;
    }
    
    function printRiderPosition(rider) {
        console.log(`${rider.name}\n  Final position: ${rider.position}`);
    }
    
    const n = Number(input.shift());
    for (let i = 0; i < n; i++) {
        const [rider, fuelCapacity, position] = input.shift().split('|');
        riders.push({ name: rider, fuelCapacity: Number(fuelCapacity), position: Number(position) });
    }
    
    for (const line of input) {
        const [command, ...params] = line.split(' - ');
        if (command === 'StopForFuel') {
            const [riderName, minFuel, changedPosition] = params;
            const riderIndex = findRiderIndex(riderName);
            if (riders[riderIndex].fuelCapacity < Number(minFuel)) {
                riders[riderIndex].position = Number(changedPosition);
                console.log(`${riderName} stopped to refuel but lost his position, now he is ${changedPosition}.`);
            } else {
                console.log(`${riderName} does not need to stop for fuel!`);
            }
        } else if (command === 'Overtaking') {
            const [rider1Name, rider2Name] = params;
            const rider1Index = findRiderIndex(rider1Name);
            const rider2Index = findRiderIndex(rider2Name);
            if (riders[rider1Index].position < riders[rider2Index].position) {
                const tempPosition = riders[rider1Index].position;
                riders[rider1Index].position = riders[rider2Index].position;
                riders[rider2Index].position = tempPosition;
                swapRiders(rider1Index, rider2Index);
                console.log(`${rider1Name} overtook ${rider2Name}!`);
            }
        } else if (command === 'EngineFail') {
            const [riderName, lapsLeft] = params;
            const riderIndex = findRiderIndex(riderName);
            console.log(`${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
            riders.splice(riderIndex, 1);
        }
    }
    
    riders.forEach(printRiderPosition);
}

race(["3","Valentino Rossi|100|1","Marc Marquez|90|2","Jorge Lorenzo|80|3","StopForFuel - Valentino Rossi - 50 - 1","Overtaking - Marc Marquez - Jorge Lorenzo","EngineFail - Marc Marquez - 10","Finish"]);
race(["4","Valentino Rossi|100|1","Marc Marquez|90|3","Jorge Lorenzo|80|4","Johann Zarco|80|2","StopForFuel - Johann Zarco - 90 - 5","Overtaking - Marc Marquez - Jorge Lorenzo","EngineFail - Marc Marquez - 10","Finish"]);
