function address(input)
{
    var addresses = {};

    for(let i = 0; i < input.length; i++)
    {
        let currentInfo = input[i].split(':');
        let currentName = currentInfo[0];
        let currentAddress = currentInfo[1];

        addresses[currentName] = currentAddress;
    }

    var sortedNames = Object.keys(addresses).sort((a, b) => a.localeCompare(b));

    for (var i = 0; i < sortedNames.length; i++) 
    {
        let name = sortedNames[i];
        let address = addresses[name];
        console.log(`${name} -> ${address}`);
    }
}
address(['Tim:Doe Crossing', 'Bill:Nelson Place', 'Peter:Carlyle Ave', 'Bill:Ornery Rd']);
address(['Bob:Huxley Rd', 'John:Milwaukee Crossing', 'Peter:Fordem Ave', 'Bob:Redwing Ave', 'George:Mesta Crossing', 'Ted:Gateway Way', 'Bill:Gateway Way', 'John:Grover Rd', 'Peter:Huxley Rd', 'Jeff:Gateway Way', 'Jeff:Huxley Rd']);