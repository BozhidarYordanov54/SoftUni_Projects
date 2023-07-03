function convertToJSON( firstName, lastName, hairColor)
{
    var person = {
        name: firstName,
        lastName: lastName,
        hairColor: hairColor
    }

    console.log(JSON.stringify(person));
}

convertToJSON('George', 'Jones','Brown');
convertToJSON('Peter', 'Smith', 'Blond');