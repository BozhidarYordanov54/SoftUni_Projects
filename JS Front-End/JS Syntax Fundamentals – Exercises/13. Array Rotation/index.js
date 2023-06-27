function rotateArray(array, numberOfRotations) 
{
    const length = array.length;
    let stringArray = "";

    if (numberOfRotations === 0) {
      return array;
    } else {
      for (let i = 0; i < numberOfRotations; i++) 
      {
        let temp = array[0]; 
  
        
        for (let j = 0; j < length - 1; j++) 
        {
          array[j] = array[j + 1];
        }
  
        array[length - 1] = temp; 
      }
    }

    for(let i = 0; i < array.length; i++)
    {
        stringArray += array[i] + " ";
    }

    console.log(stringArray);
  }

rotateArray([51, 47, 32, 61, 21], 2 );
rotateArray([32, 21, 61, 1], 4);