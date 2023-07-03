function city(obj)
{
    for(var key in obj)
    {
        console.log(`${key} -> ${obj[key]}`);
    }
}

let cityObj = 
{
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
};

city(cityObj)