function sortNumbers(numbers) 
{
    // Sort the numbers in ascending order
    numbers.sort((a, b) => a - b);
  
    // Create a new array to store the sorted result
    const sortedArray = [];
  
    let left = 0;
    let right = numbers.length - 1;
  
    while (left <= right) 
    {
      if (left === right) 
      {
        sortedArray.push(numbers[left]);
      } 
      else 
      {
        sortedArray.push(numbers[left]);
        sortedArray.push(numbers[right]);
      }
  
      left++;
      right--;
    }
  
    return sortedArray;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56] ));