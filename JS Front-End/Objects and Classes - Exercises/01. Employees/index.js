function employees(employeeList)
{
    class Employee
    {
        constructor(name, personalNumber)
        {
            this.name = name;
            this.personalNumber = personalNumber;
        }
    }

    let employees = [];

    for(let i = 0; i < employeeList.length; i++)
    {
        let name = employeeList[i];
        let id = name.length;

        let employee = new Employee(name, id);
        employees[i] = employee;
    }

    for(let employee of employees)
    {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
    }
}