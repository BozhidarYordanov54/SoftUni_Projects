function radar(speed, area)
{
    let speedLimit = 0;
    let status = "";

    switch(area)
    {
        case "motorway":
            speedLimit = 130;
            break;
        case "interstate":
            speedLimit = 90;
            break;
        case "city":
            speedLimit = 50;
            break;
        case "residential":
            speedLimit = 20;
            break;
    }

    let speedDifference = Math.abs(speed - speedLimit);
    

    if(speed <= speedLimit)
    {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        return;
    }
    else
    {
        if(speedDifference <= 20)
        {
            status = "speeding";
        }
        else if(speedDifference <= 40)
        {
            status = "excessive speeding";
        }
        else
        {
            status = "reckless driving";
        }
    }

    console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
}

radar(40, 'city');
radar(21, 'residential');
radar(120, 'interstate');