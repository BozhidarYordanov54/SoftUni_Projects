function powerOfNumber(base, power)
{
    let result = 1;

    for(let i = 1; i <= power; i++)
    {
        result *= base;
    }

    console.log(result);
}

powerOfNumber(2,8);
powerOfNumber(3,4);