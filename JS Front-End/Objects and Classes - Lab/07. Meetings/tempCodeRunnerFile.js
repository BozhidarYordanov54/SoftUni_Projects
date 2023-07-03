function meetingsManager(meetings)
{
    var meetings = {};

    for(let i = 0; i < meetings.length; i++)
    {
        let appointment = meetings[i].split(' ');
        let weekday = appointment[0];
        let name = appointment[1];

        if(meetings[weekday])
        {
            console.log("Conflict on " + weekday + "!");
        }
        else
        {
            meetings[weekday] = person;
            meetings.push(appointment);
            console.log(`Scheduled for ${weekday}`);
        }
    }
}