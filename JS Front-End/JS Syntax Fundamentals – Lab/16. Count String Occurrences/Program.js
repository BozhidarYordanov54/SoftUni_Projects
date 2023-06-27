function stringOccurence(string, searchedWord){
    let words = string.split(' ');
    let counter = 0;

    for(let word of words)
    {
        if(word == searchedWord)
        {
            counter++;
        }
    }

    console.log(counter);
}

stringOccurence('This is a word and it also is a sentence','is');
stringOccurence('softuni is great place for learning new programming languages','softuni');