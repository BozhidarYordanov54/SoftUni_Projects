function calc() {
    let num1 = document.getElementById('num1').value;
    let num2 = document.getElementById('num2').value;
    
    num1 = parseFloat(num1);
    num2 = parseFloat(num2);

    var sum = num1 + num2;

    let result = document.getElementById('sum').value = sum;
}
