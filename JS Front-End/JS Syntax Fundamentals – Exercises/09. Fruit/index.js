function calculatePrice(fruitType, weightInGrams, pricePerKg)
{
    const weightInKgs = weightInGrams / 1000;
    const moneyNeeded = weightInKgs * pricePerKg;

    console.log(`I need \$${moneyNeeded.toFixed(2)} to buy ${weightInKgs.toFixed(2)} kilograms ${fruitType}.`);
}

calculatePrice('orange', 2500, 1.80);
calculatePrice('apple', 1563, 2.35);