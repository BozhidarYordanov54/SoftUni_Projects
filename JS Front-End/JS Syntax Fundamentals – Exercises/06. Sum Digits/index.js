function digitSum(number)
{
    const numberLenght = String(number);
    let sum = 0;

    for(let i = 0; i < numberLenght.length; i++)
    {
        sum += parseInt(numberLenght[i]);
    }

    console.log(sum);
}

digitSum(245678);
digitSum(97561);
digitSum(543);
