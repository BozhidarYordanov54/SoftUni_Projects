function repeatString(string, timesToRepeat)
{
    let resultString = '';

    for(let i = 0; i < timesToRepeat; i++)
    {
        resultString += string;
    }

    console.log(resultString);
}