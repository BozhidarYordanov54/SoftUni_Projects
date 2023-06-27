function substring(string, startIndex, endIndex)
{
    const substring = string.substr(startIndex, endIndex);

    console.log(substring);
}

substring('ASentence', 1, 8);
substring('SkipWord', 4, 7);