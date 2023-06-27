function uppercaseWords(sentence) {
    const sentenceWords = sentence.split(/\b(\w+)\b/);
    const words = [];
  
    for (let i = 0; i < sentenceWords.length; i++) {
      const word = sentenceWords[i].replace(/[^\w\s]|_/g, "").replace(/\s/g, "").toUpperCase();
      if (word !== "") {
        words.push(word);
      }
    }
  
    console.log(words.join(', '));
  }

uppercaseWords('Hi, how are you?' );
uppercaseWords('hello');