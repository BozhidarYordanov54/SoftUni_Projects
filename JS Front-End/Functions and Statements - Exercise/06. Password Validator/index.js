function validatePassword(password) 
{
    const lengthRegex = /^.{6,10}$/;
    const letterDigitRegex = /^[a-zA-Z0-9]+$/;
    const digitRegex = /\d{2}/;

    if (!lengthRegex.test(password)) 
    {
        console.log("Password must be between 6 and 10 characters");
    }

    if (!letterDigitRegex.test(password)) 
    {
        console.log("Password must consist only of letters and digits");
    }

    if (!digitRegex.test(password)) 
    {
        console.log("Password must have at least 2 digits");
    }

    if (lengthRegex.test(password) && letterDigitRegex.test(password) && digitRegex.test(password)) 
    {
        console.log("Password is valid");
    }
}