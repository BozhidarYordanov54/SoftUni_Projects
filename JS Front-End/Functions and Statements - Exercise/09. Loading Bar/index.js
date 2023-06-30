function loadingBar(percentage)
{
    const bar = ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.'];

    for(let i = 0; i < percentage / 10; i++)
    {
        bar[i] = '%';
    }

    if(percentage == 100)
    {
        console.log(`100% Complete!`);
        console.log(`[${bar.join('')}]`);
        return;
    }

    console.log(`${percentage}% [${bar.join('')}]`);
    console.log(`Still loading...`);
}

loadingBar(30);
loadingBar(50);
loadingBar(100);

