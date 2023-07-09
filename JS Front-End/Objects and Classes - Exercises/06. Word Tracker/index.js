function wordTracker(wordArr)
{
    let searchedWords = wordArr[0].split(' ');
    let words = wordArr.slice(1);

    const wordCounts = {};
    
    for(let i = 0; i < searchedWords.length; i++)
    {
        wordCounts[searchedWords[i]] = 0;

        for(let j = 0; j < words.length; j++)
        {
            if(words[j] == searchedWords[i])
            {
                wordCounts[searchedWords[i]]++;
            }
        }
    }

    const sortedWords = Object.entries(wordCounts).sort(
        (a, b) => b[1] - a[1]
      );

      sortedWords.forEach(([word, count]) => {
        console.log(`${word} - ${count}`);
      });
}

wordTracker([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task'
    ]
    );