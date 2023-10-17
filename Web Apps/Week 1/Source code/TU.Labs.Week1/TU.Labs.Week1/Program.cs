using System.Text.RegularExpressions;
using TU.Labs.Week1;

Console.WriteLine("Hello, World!");
List<Employee> employeeList = new List<Employee>();
int option;
while (true)
{
      Console.WriteLine("Please select an option:");
      Console.WriteLine("1. Add Employee");
      Console.WriteLine("2. List Employees");
      Console.WriteLine("3. Remove Employee");
      Console.WriteLine("4. Quit/Exit");
      // Check if user input is a valid integer
      if (int.TryParse(Console.ReadLine(), out option))
      {
            switch (option)
            {
                  case 1: // Add Employee
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
                        // Add the employee to the list
                        employeeList.Add(employee);
                        break;
                  case 2: // List Employees
                        Console.WriteLine("Employee List:");
                        for (int i = 0; i < employeeList.Count; i++)
                        {
                              Console.WriteLine($"{i + 1}. {employeeList[i].EmployeeName}");
                        }
                        break;
                  case 3: // Remove Employee
                        Console.WriteLine("Please enter the position number of the Employee you would like to remove:");
                        int positionNumber = Convert.ToInt32(Console.ReadLine());
                        if (positionNumber > 0 && positionNumber <= employeeList.Count)
                        {
                              Console.WriteLine($"Removing {employeeList[positionNumber - 1].EmployeeName} from the list...");
                              employeeList.RemoveAt(positionNumber - 1);
                        }
                        else
                        {
                              Console.WriteLine("Invalid position number!");
                        }
                        break;
                  case 4: // Quit/Exit
                        Console.WriteLine("Exiting...");
                        return;
                  default:
                        Console.WriteLine("Invalid Option!");
                        break;
            }
      }
      else
      {
            Console.WriteLine("Invalid input, please enter a valid option.");
      }

}