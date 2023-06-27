let name = readlineSync.question("");
let age = prompt("");
let grade = prompt("");

multiplyByTwo(name, age, grade)

function multiplyByTwo(name, age, grade)
{
    console.log(`Name: ${name}, Age: ${age}, Grade: ${grade.toFixed(2)}`)
}