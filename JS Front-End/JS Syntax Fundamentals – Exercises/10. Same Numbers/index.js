function sameNumber(number)
{
    if(Number.isInteger(number))
    {
        let sum = 0;
        let sameNumber = true;
        const numberLenght = String(number);
        const firstDigit = numberLenght[0];

        for(let i = 0; i < numberLenght.length; i++)
        {
            sum += parseInt(numberLenght[i]);

            if(numberLenght[i] !== firstDigit)
            {
                sameNumber = false;
            }
        }

        console.log(sameNumber);
        console.log(sum);
    }
}

sameNumber(2222222);
sameNumber(1234);


