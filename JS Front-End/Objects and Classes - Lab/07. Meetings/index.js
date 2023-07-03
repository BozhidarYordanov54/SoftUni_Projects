function meetingsManager(appointments)
{
   var meetings = {};

   for(let i = 0; i < appointments.length; i++)
   {
        let currentAppointment = appointments[i].split(' ');
        let weekday = currentAppointment[0];
        let person = currentAppointment[1];

        if(meetings.hasOwnProperty(weekday))
        {
            console.log(`Conflict on ${weekday}!`);
        }
        else
        {
            meetings[weekday] = person;
            console.log(`Scheduled for ${weekday}`);
        }
   }

   for(var key in meetings)
   {
        console.log(`${key} -> ${meetings[key]}`);
   }
}

meetingsManager(['Friday Bob', 'Saturday Ted', 'Monday Bill', 'Monday John', 'Wednesday George']);