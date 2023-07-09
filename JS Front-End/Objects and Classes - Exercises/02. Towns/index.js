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