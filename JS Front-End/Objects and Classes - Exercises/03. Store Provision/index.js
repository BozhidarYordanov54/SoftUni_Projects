function updateStock(stock, orders) 
{
    const mergedStock = {};
  
    
    for (let i = 0; i < stock.length; i += 2) 
    {
      const product = stock[i];
      const quantity = Number(stock[i + 1]);
  
      mergedStock[product] = mergedStock[product] || 0;
      mergedStock[product] += quantity;
    }
  
    // Process product orders
    for (let i = 0; i < orders.length; i += 2) {
      const product = orders[i];
      const quantity = Number(orders[i + 1]);
  
      mergedStock[product] = mergedStock[product] || 0;
      mergedStock[product] += quantity;
    }
  
    for (let product in mergedStock) 
    {
        console.log(`${product} -> ${mergedStock[product]}`);
    }
}