function formatGrade(grade)
{
    let gradeDescription = '';

    if(grade < 3)
    {
        console.log(`Fail (2)`);
        return;
    }
    else if(grade >= 3.00 && grade < 3.50)
    {
        gradeDescription = 'Poor';
    }
    else if(grade >= 3.50 && grade < 4.50)
    {
        gradeDescription = 'Good';
    }
    else if(grade >= 4.50 && grade < 5.50)
    {
        gradeDescription = 'Very good';
    }
    else
    {
        gradeDescription = 'Excellent';
    }

    console.log(`${gradeDescription} (${grade.toFixed(2)})`);
}

formatGrade(3.33);
formatGrade(4.50);
formatGrade(2.99);