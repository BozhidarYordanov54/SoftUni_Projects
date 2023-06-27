Reverse(3, [10, 20, 30, 40, 50]);
Reverse(4, [-1, 20, 99, 5] );
Reverse(2, [66, 43, 75, 89, 47] );

function Reverse(n, array)
{
    let reversedArr = "";

    for(let i = n - 1; i >= 0; i--)
    {
       reversedArr += array[i] + " ";
    }

    console.log(reversedArr);
}