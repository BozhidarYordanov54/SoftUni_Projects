CircleArea(5);
CircleArea(`name`);

function CircleArea(input)
{
    let result = 0;

    if(typeof(input) === 'number')
    {
        result = (Math.pow(input, 2) * Math.PI).toFixed(2);
        console.log(result);
    }
    else
    {
        console.log(`We can not calculate the circle area, because we receive a ${typeof input}.`);
        return;
    }
}