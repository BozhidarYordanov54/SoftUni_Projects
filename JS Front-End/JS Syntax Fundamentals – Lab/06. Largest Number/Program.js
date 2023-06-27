LargestNumber(5, -3, 16);
LargestNumber(-3, -5, -22.5 );

function LargestNumber(num1, num2, num3)
{
    let largestNum = num1;

    if(num1 > num2 && num1 > num3)
    {
        largestNum = num1;
    }
    else if(num2 > num1 && num2 > num3)
    {
        largestNum = num2;
    }
    else if(num3 > num1 && num3 > num2)
    {
        largestNum = num3;
    }

    console.log(`The largest number is ${largestNum}.`);
}