function censoredWord(text, word)
{
    const censoredWord = "*".repeat(word.length);
    let censoredText = text;

    while(censoredText.includes(word))
    {
        censoredText = censoredText.replace(word, censoredWord);
    }

    console.log(censoredText);
}

censoredWord('A small sentence with some words', 'small');
censoredWord('Find the hidden word', 'hidden');