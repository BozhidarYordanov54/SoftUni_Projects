function login(input) 
{
   const username = input[0];
   let attempts = 0;
   
   for(let i = 1; i < input.length; i++)
   {
        let correctPassword = input[i].split('').reverse().join('');

        if(username == correctPassword)
        {
            console.log(`User ${username} logged in.`);
            return;
        }
        else if(attempts == 3)
        {
            console.log(`User ${username} blocked!`);
            return;
        }
        else
        {
            console.log("Incorrect password. Try again.");
            attempts++;
        }
        
   }
}


login(['Acer','login','go','let me in','recA']);
login(['momo','omom'] );
login(['sunny','rainy','cloudy','sunny','not sunny']);