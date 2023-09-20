function solve(array){
    let n = parseInt(array[0]);
    let astronauts = {};

    // Proccess astronauts details
    for(let i = 1; i <= n; i++)
    {
        let [astronaut, oxygenLevel, energy] = array[i].split(" ");
        astronauts[astronaut] = {
            oxygenLevel: parseInt(oxygenLevel),
            energy: parseInt(energy)
        };
    }

    let index = n + 1;
    while (index < array.length && array[index] !== "End")
    {
        let [action, astronaut, arg1] = array[index].split(" - ");

        if(action === "Explore")
        {
            let neededEnergy = parseInt(arg1);

            if(astronauts[astronaut].energy < neededEnergy)
            {
                console.log(`${astronaut} does not have enough energy to explore!`);
                
            }
            else{
                astronauts[astronaut].energy -= neededEnergy;
                console.log(`${astronaut} has successfully explored a new area and now has ${astronauts[astronaut].energy} energy!`);
            }
        }
        else if(action === "Refuel")
        {
            let refuelAmount = parseInt(arg1);

            if(astronauts[astronaut].energy + refuelAmount > 200)
            {
                let recoveredEnergy = 200 - astronauts[astronaut].energy;
                astronauts[astronaut].energy = 200;

                console.log(`${astronaut} refueled their energy by ${recoveredEnergy}!`);
            }
            else
            {
                astronauts[astronaut].energy += refuelAmount;
                console.log(`${astronaut} refueled their energy by ${refuelAmount}!`);
            }

            
        }
        else if(action === "Breathe")
        {
            let oxygenAmount = parseInt(arg1);

            if (astronauts[astronaut].oxygenLevel + oxygenAmount > 100) 
            {
                let recoveredOxygen = 100 - astronauts[astronaut].oxygenLevel; 
            
                astronauts[astronaut].oxygenLevel = 100; 
                console.log(`${astronaut} took a breath and recovered ${recoveredOxygen} oxygen!`);
            } else 
            {
                astronauts[astronaut].oxygenLevel += oxygenAmount; 
                console.log(`${astronaut} took a breath and recovered ${oxygenAmount} oxygen!`);
            }
        }

        index++;
    }

    for(let astronaut in astronauts)
    {
        console.log(`Astronaut: ${astronaut}, Oxygen: ${astronauts[astronaut].oxygenLevel}, Energy: ${astronauts[astronaut].energy}`);
    }
}

solve([  '4',
    'Alice 60 100',
    'Bob 40 80',
    'Charlie 70 150',
    'Dave 80 180',
    'Explore - Bob - 60',
    'Refuel - Alice - 30',
    'Breathe - Charlie - 50',
    'End'
]);