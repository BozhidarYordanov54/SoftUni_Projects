function charactersInRange(charOne, charTwo)
{
    let startCode = charOne.charCodeAt(0);
    let endCode = charTwo.charCodeAt(0);

    if(startCode > endCode)
    {
        let temp = startCode;
        startCode = endCode;
        endCode = temp;
    }

    let output = '';
   
    for(let i = startCode + 1; i < endCode; i ++)
    {
        output += String.fromCharCode(i) + " ";
    }
    
    console.log(output);
}

charactersInRange('a', 'd');
charactersInRange('#', ':');
charactersInRange('C', '#');
