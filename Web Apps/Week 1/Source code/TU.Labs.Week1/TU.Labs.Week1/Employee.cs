using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU.Labs.Week1
{
      internal class Employee
      {
            public string EmployeeName { get; set; }
            public string EmployeeId { get; set; }
            public double HoursWorked { get; set; }
            public double HourlyRate { get; set; }

            public Employee(string employeeName, string employeeId, double hoursWorked)
            {
                  EmployeeName = employeeName;
                  EmployeeId = employeeId;
                  HoursWorked = hoursWorked;
                  HourlyRate = 9.5;
            }

            public override string ToString()
            {
                  return $"{EmployeeName} ({EmployeeId}).";
            }

            public double CalculateWage()
            {
                  return HoursWorked * HourlyRate;
            }
      }
}