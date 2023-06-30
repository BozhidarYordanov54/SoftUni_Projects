function expenses(lostFights, helmPrice, swordPrice, shieldPrice, armorPrice)
{
    let totalExpenses = 0;
    let helmetBreakInterval = 2;
    let swordBreakInterval = 3;
    let shieldBrokenCount = 0;

    for(let i = 1; i <= lostFights; i++)
    {
        //check for helmet break
        if(i % helmetBreakInterval == 0)
        {
            totalExpenses += helmPrice;
        }

        //check for sword break
        if(i % swordBreakInterval == 0)
        {
            totalExpenses += swordPrice;
        }

        if(i % helmetBreakInterval == 0 && i % swordBreakInterval == 0)
        {
            totalExpenses += shieldPrice;
            shieldBrokenCount++;
        }

        if(shieldBrokenCount == 2)
        {
            shieldBrokenCount = 0;
            totalExpenses += armorPrice;
        }
    }

    console.log(`Gladiator expenses: ${totalExpenses.toFixed(2)} aureus`);
}

expenses(7, 2, 3, 4, 5);


//every second loss the helmet is broken
//every third loss the sword is broken
//when the helmet and sword are broken the shield breaks
//every second time the shield is broken the armour needs to be repaired