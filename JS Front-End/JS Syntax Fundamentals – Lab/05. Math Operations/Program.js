solve(5, 6, '+')
solve(3, 5.5, '*')

function solve(num1, num2, operator)
{
    let result;

  switch (operator) {
    case '+':
      result = num1 + num2;
      break;
    case '-':
      result = num1 - num2;
      break;
    case '*':
      result = num1 * num2;
      break;
    case '/':
      result = num1 / num2;
      break;
    case '%':
      result = num1 % num2;
      break;
    case '**':
      result = num1 ** num2;
      break;
    default:
      console.log('Invalid operator');
      return;
  }

  console.log(result);
}