function phoneBook(phoneBook)
{
    var phoneBookMap = {};

    for (var i = 0; i < phoneBook.length; i++) 
    {
        var entry = phoneBook[i].split(" ");
        var name = entry[0];
        var number = entry[1];
    
        phoneBookMap[name] = number;
    }

    for(var name in phoneBookMap)
    {
        console.log(`${name} -> ${phoneBookMap[name]}`);
    }
}

phoneBook(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']);
//phoneBook(['George 0552554', 'Peter 087587', 'George 0453112', 'Bill 0845344']);