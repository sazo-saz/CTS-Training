using System;
using System.Collections.Generic;
using System.Linq;
class LINQExample
{
    public class Student
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public int Marks { get; set; }
    }
    static void Main()
    {
        var students = new List<Student>
       {
           new Student { Name = "Alice", Dept = "CSE", Marks = 85 },
           new Student { Name = "Bob", Dept = "ECE", Marks = 70 },
           new Student { Name = "Charlie", Dept = "CSE", Marks = 90 },
           new Student { Name = "David", Dept = "EEE", Marks = 60 }
       };
        // Filtering
        var highScorers = students.Where(s => s.Marks > 75);
        // Projection
        var namesOnly = students.Select(s => s.Name);
        // Ordering
        var orderedByMarks = students.OrderByDescending(s => s.Marks);
        // Grouping
        var groupedByDept = students.GroupBy(s => s.Dept);
        // Aggregation
        var avgMarks = students.Average(s => s.Marks);
        // Quantifiers
        bool anyCSE = students.Any(s => s.Dept == "CSE");
        bool allPassed = students.All(s => s.Marks >= 35);
        Console.WriteLine("High Scorers:");
        foreach (var s in highScorers) Console.WriteLine($"{s.Name} - {s.Marks}");
        Console.WriteLine("\nGrouped by Department:");
        foreach (var group in groupedByDept)
        {
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.Select(s => s.Name))}");
        }
        Console.WriteLine($"\nAverage Marks: {avgMarks}");
        Console.WriteLine($"Any in CSE: {anyCSE}");
        Console.WriteLine($"All Passed: {allPassed}");
    }
}