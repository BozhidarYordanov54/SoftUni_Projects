function containsWord(wordToSearch, sentence)
{
    const sentenceWords = sentence.split(' ');
    wordToSearch.toLowerCase();
    const notFound = false;

    for(let i = 0; i < sentenceWords.length; i++)
    {
        const currentWord = sentenceWords[i].toLowerCase();

        if(currentWord == wordToSearch)
        {
            console.log(currentWord);
            notFound = true;
            return;
        }
    }

    if(notFound)
    {
        console.log(`${wordToSearch} not found!`);
    }
}