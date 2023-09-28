using System.Text.RegularExpressions;
using TU.Labs.Week1;

Console.WriteLine("Hello, World!");
string employeeName;
// Ask the user to enter an Employee Name and Validate Employee Name
while (true)
{
      Console.WriteLine("Please enter an Employee Name (1-50 characters):");
      employeeName = Console.ReadLine();
      if (employeeName.Length >= 1 && employeeName.Length <= 50)
            break;
      Console.WriteLine("Employee Name is not in the correct format!");
}
string employeeId;

while (true)
{
      Console.WriteLine("Please enter an Employee Id (a letter followed by two digits):");
      employeeId = Console.ReadLine().ToUpper();
      if (Regex.IsMatch(employeeId, @"^[A-Z][0-9]{2}$"))
            break;
      Console.WriteLine("Employee ID is not in the correct format!");
}

// Ask the user to enter Hours Worked
double hoursWorked;
while (true)
{
      Console.WriteLine("Please enter hours worked (1-100):");
      hoursWorked = Convert.ToDouble(Console.ReadLine());
      if (hoursWorked >= 1 && hoursWorked <= 100)
            break;
      Console.WriteLine("Hours Worked is not in the correct format!");
}
// Create the Employee object
Employee employee = new Employee(employeeName, employeeId, hoursWorked);
// Calculate the weekly wage
double weeklyWage = employee.CalculateWage();
// Display the weekly wage with two decimal places
Console.WriteLine($"The weekly wage is £{weeklyWage:F2}");