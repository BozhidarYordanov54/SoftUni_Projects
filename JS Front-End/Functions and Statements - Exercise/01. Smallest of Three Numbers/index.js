function smallestNum(numOne, numTwo, numThree)
{
    var smallest = numOne;

  if (numTwo < smallest) 
  {
    smallest = numTwo;
  }
  if (numThree < smallest) 
  {
    smallest = numThree;
  }

  console.log(smallest);
}