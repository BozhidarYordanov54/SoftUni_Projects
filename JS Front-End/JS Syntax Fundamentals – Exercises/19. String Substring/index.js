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
            return;
        }
    }

    
    console.log(`${wordToSearch} not found!`);
}
    

containsWord('javascript','JavaScript is the best programming language');
containsWord('python', 'JavaScript is the best programming language');