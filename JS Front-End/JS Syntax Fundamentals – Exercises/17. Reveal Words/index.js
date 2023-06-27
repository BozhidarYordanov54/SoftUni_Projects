function replaceWords(wordsString, templateString) 
{
    const replacedWords = wordsString.split(', ');
    const sentenceWords = templateString.split(' ');
  
    let wordIndex = 0;
  
    for (let i = 0; i < sentenceWords.length; i++) 
    {
      const currentWord = sentenceWords[i];
  
    if (currentWord.startsWith("*")) 
    {
        sentenceWords[i] = replacedWords[wordIndex];
        wordIndex++;
  
        if (wordIndex >= replacedWords.length) 
        {
          wordIndex = 0;
        }
    }
}
  
    const newSentence = sentenceWords.join(' ');
    console.log(newSentence);
}
  
  replaceWords('great', 'softuni is ***** place for learning new programming languages');
  replaceWords('great, learning', 'softuni is ***** place for ******** new programming languages');
  