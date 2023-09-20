function town(townArr)
{
    for(let i = 0; i < townArr.length; i++)
    {
        let [town, latitude, longitude] = townArr[i].split(' | ');

        let townObj = {
            town: town,
            latitude: Number.parseFloat(latitude).toFixed(2),
            longitude: Number.parseFloat(longitude).toFixed(2)
        }

        console.log(townObj);
    }

}

console.log(town(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']));
console.log(town(['Plovdiv | 136.45 | 812.575']));