function calculatePrice(peopleCount, peopleType, dayOfWeek)
{
    let singlePersonPrice = 0;
    let totalPrice = 0;

    switch(peopleType)
    {
        case "Students":
            switch(dayOfWeek)
            {
                case "Friday":
                    singlePersonPrice = 8.45;
                break;
                case "Saturday":
                    singlePersonPrice = 9.80;
                break;
                case "Sunday":
                    singlePersonPrice = 10.46;
                break;
            }
            totalPrice = peopleCount * singlePersonPrice;

            if(peopleCount >= 30)
            {
                totalPrice -= totalPrice * 0.15;
            }
        break;

        case "Business":
            switch(dayOfWeek)
            {
                case "Friday":
                    singlePersonPrice = 10.90;
                break;
                case "Saturday":
                    singlePersonPrice = 15.60;
                break;
                case "Sunday":
                    singlePersonPrice = 16;
                break;
            }

            if(peopleCount >= 100)
            {
                peopleCount /= 10;
                totalPrice = peopleCount * singlePersonPrice;
            }
            else
            {
                totalPrice = peopleCount * singlePersonPrice;
            }
        break;

        case "Regular":
            switch(dayOfWeek)
            {
                case "Friday":
                    singlePersonPrice = 15;
                break;
                case "Saturday":
                    singlePersonPrice = 20;
                break;
                case "Sunday":
                    singlePersonPrice = 22.50;
                break;
            }
            totalPrice = peopleCount * singlePersonPrice;

            if(peopleCount >= 10 && peopleCount <= 20)
            {
                totalPrice -= totalPrice * 0.05;
            }
        break;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

