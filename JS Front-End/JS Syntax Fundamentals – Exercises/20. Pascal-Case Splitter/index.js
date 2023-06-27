function splitPascalCaseString(inputString) 
{
    const words = inputString.split(/(?=[A-Z])/);
    const result = words.join(', ');
  
    console.log(result);
}