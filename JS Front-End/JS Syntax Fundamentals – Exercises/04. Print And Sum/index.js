function printAndSum(startIndex, endIndex)
{
    let sum = 0;
    let numString = "";

    for(let i = startIndex; i <= endIndex; i++)
    {
        numString += i + " ";
        sum += i;
    }

    console.log(numString);
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10);
printAndSum(0, 26);