function numberCooking(number, operation1, operation2, operation3, operation4, operation5)
{
    let convertedNumber = parseFloat(number);
    const operations = [operation1, operation2, operation3, operation4, operation5];

    for(let operation of operations)
    {
        switch(operation)
        {
            case "chop":
                convertedNumber /= 2;
                break;
            case "dice":
                convertedNumber = Math.sqrt(convertedNumber);
                break;
            case "spice":
                convertedNumber += 1;
                break;
            case "bake":
                convertedNumber *= 3;
                break;
            case "fillet":
                convertedNumber -= convertedNumber * 0.2;
                break;
        }

        console.log(convertedNumber);
    }
}

//numberCooking('32', 'chop', 'chop', 'chop', 'chop', 'chop');
numberCooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet');