function calculateSpiceYield(startingYield) 
{
    let totalSpice = 0;
    let daysOperated = 0;
  
    while (startingYield >= 100) 
    {
      totalSpice += startingYield;
      daysOperated++;
      startingYield -= 10;
      
      if (totalSpice >= 26) 
      {
        totalSpice -= 26;
      } 
      else 
      {
        totalSpice = 0;
      }

      
    }

    totalSpice -= 26;
  
    if (totalSpice < 0) 
    {
      totalSpice = 0;
    }

    console.log(daysOperated);
    console.log(totalSpice);
  
}

calculateSpiceYield(111);
calculateSpiceYield(450);