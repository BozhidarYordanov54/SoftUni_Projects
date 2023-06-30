function reciept(item, timesBought)
{
    let totalPrice = 0

    switch(item)
    {
        case "coffee":
            totalPrice = timesBought * 1.5;
            break;
        case "water":
            totalPrice = timesBought * 1.00;
            break;
        case "coke":
            totalPrice = timesBought * 1.40;
            break;
        case "snacks":
            totalPrice = timesBought * 2.00;
            break;
    }
    
    console.log(totalPrice.toFixed(2));
}