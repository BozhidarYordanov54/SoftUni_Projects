EvenOddDifference([1,2,3,4,5,6]);
EvenOddDifference([3,5,7,9]);
EvenOddDifference([2,4,6,8,10]);

function EvenOddDifference(arr)
{
    let oddSum = 0;
    let evenSum = 0;

    for(let i = 0; i < arr.length; i++)
    {
        if(arr[i] % 2 == 0)
        {
            evenSum += arr[i];
        }
        else
        {
            oddSum += arr[i];
        }
    }

    console.log(evenSum - oddSum)
}