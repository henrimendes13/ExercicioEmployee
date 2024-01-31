using ExercicioEmployee.Entities;
using System.Text.Json.Serialization;

Console.Write("Enter full file path: ");
string path = Console.ReadLine();

List<Employee> list = new List<Employee>();

using (StreamReader sr = File.OpenText(path))
{
    while (!sr.EndOfStream)
    {
        string[] line = sr.ReadLine().Split(',');
        string name = line[0];
        string email = line[1];
        double salary = double.Parse(line[2]);

        list.Add(new Employee(name, email, salary));
    }

    Console.Write("Enter salary: ");
    double salary2 = double.Parse(Console.ReadLine());

    Console.WriteLine($"Email of people whose salary is more than {salary2}: ");

    var emails = list.
        Where(x => x.Salary > salary2).
        OrderBy(x => x.Email).
        Select(x => x.Email);
    
    foreach (string email  in emails)
    {
        Console.WriteLine(email);
    }

}


