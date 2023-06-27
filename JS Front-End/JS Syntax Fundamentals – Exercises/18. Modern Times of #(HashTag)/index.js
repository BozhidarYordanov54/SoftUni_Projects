function hashTagWords(sentence)
{
    const words = sentence.split(' ');
    const specialWords = [];

    for(let i = 0; i < words.length; i++)
    {
        const currentWord = words[i];

        if(currentWord.startsWith('#'))
        {
            const specialWord = currentWord.slice(1);

            if (/^[a-zA-Z]+$/.test(specialWord)) 
            {
                specialWords.push(specialWord);
            }
        }
    }

    for(let i = 0; i < specialWords.length; i++)
    {
        console.log(specialWords[i]);
    }
}