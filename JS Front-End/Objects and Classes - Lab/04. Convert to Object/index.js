function convertObject(jsonString) 
{
    var obj = JSON.parse(jsonString);
  
    for (var key in obj) 
    {
      console.log(key + ": " + obj[key]);
    }
}

convertObject('{"name": "George", "age": 40, "town": "Sofia"}');