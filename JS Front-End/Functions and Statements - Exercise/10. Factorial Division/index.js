function factorialDivision(numOne, numTwo)
{
    let factorialOne = 1;
    let factorialTwo = 1;

    for(let i = 1; i <= numOne; i++)
    {
        factorialOne *= i;
    }

    for(let i = 1; i <= numTwo; i++)
    {
        factorialTwo *= i;
    }

    console.log((factorialOne / factorialTwo).toFixed(2));
}

factorialDivision(5, 2);
factorialDivision(6, 2);