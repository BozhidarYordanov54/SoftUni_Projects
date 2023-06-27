function nthElement(array, step)
{
    const resultArray = [];

    for(let i = 0; i < array.length; i += step)
    {
        resultArray.push(array[i]);
    }

    return resultArray;
}

console.log(nthElement(['5', '20', '31', '4', '20'], 2));
