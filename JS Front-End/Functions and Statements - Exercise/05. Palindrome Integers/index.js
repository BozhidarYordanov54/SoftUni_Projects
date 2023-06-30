function palindromeNumbers(numArr)
{
    for(let i = 0; i < numArr.length; i++)
    {
        const currentNum = numArr[i].toString();
        const reversedNum = currentNum.split('').reverse().join('');

        if(currentNum === reversedNum)
        {
            console.log(`true`);
        }
        else
        {
            console.log(`false`);
        }
    }
}

palindromeNumbers([123,323,421,121]);
palindromeNumbers([32,2,232,1010] );