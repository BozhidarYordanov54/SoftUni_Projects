function NxNMatrix(number)
{

    for(let i = 0; i < number; i++)
    {
        let row = '';
        for(let j = 0; j < number; j++)
        {
            row += number + ' ';
        }
        console.log(row);
    }
}

NxNMatrix(3);
NxNMatrix(7);