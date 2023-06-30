function oddOrEvenSum(num)
{
    let numToString = num.toString();
    let oddSum = 0;
    let evenSum = 0;

    for(let i = 0; i < numToString.length; i++)
    {
        let currentDigit = parseInt(numToString[i]);

        if(currentDigit % 2 == 0)
        {
            evenSum += currentDigit;
        }
        else
        {
            oddSum += currentDigit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddOrEvenSum(1000435);
oddOrEvenSum(3495892137259234);