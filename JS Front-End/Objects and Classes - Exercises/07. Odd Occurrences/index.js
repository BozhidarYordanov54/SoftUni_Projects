function oddOccurrences(input) {
    let inputSplit = input.toLowerCase().split(" ");
    const wordCounts = {};
  
    for (let i = 0; i < inputSplit.length; i++) 
    {
      if (!wordCounts[inputSplit[i]]) {
        wordCounts[inputSplit[i]] = 0;
      }
      wordCounts[inputSplit[i]]++;
    }
  
    let output = "";
  
    for (let word in wordCounts) {
      if (wordCounts[word] % 2 !== 0) {
        output += word + " ";
      }
    }
  
    console.log(output.trim());
  }
  
  oddOccurrences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
  